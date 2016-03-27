using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Utils
{
	public static class AudioPlayer
	{
		private static class AudioManager
		{
			public const int NUM_CHANNELS = 64;

			private static HashSet<AudioChannel> channels;

			static AudioManager()
			{
				channels = new HashSet<AudioChannel>();

				GameObject obj = new GameObject("Audio Manager");
				UnityEngine.Object.DontDestroyOnLoad(obj);

				for(int i = 0; i < NUM_CHANNELS; i++)
				{
					GameObject channel = new GameObject("AudioChannel " + i);
					channel.transform.SetParent(obj.transform);

					channel.AddComponent<AudioSource>();
					channels.Add(channel.AddComponent<AudioChannel>());
				}
			}

			internal static AudioChannel GetNext()
			{
				foreach(AudioChannel channel in channels)
				{
					if(!channel.IsPlaying)
					{
						return channel;
					}
				}

				return null;
			}
		}

		public static AudioChannel Play(this AudioObject audioObject)
		{
			if(audioObject is AudioObjectSingle)
			{
				AudioChannel channel = AudioManager.GetNext();

				if(channel != null)
				{
					channel.Play(audioObject as AudioObjectSingle);
					return channel;
				}
				else
				{
					Debug.LogWarning("No free AudioChannels");
				}
			}
			else if(audioObject is AudioObjectMultiple)
			{
				AudioObjectMultiple group = audioObject as AudioObjectMultiple;
				AudioObjectSingle next = group.Next();

				if(next != null)
				{
					return next.Play();
				}
			}
			else
			{
				Debug.LogError("Unknown AudioObject type: " + audioObject.GetType());
			}

			return null;
		}
	}
}
