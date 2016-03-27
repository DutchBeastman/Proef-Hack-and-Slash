//Created By: Jeremy Bond
//Date: 27/03/2016

using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
	public class AudioPlayer2 : MonoBehaviour
	{
		[SerializeField] private int maxChannels;
		private HashSet<AudioChannel2> channels;

		private const string AUDIOEVENT = "audioEvent";

		protected void Awake ()
		{
			channels = new HashSet<AudioChannel2> ();
			for (int i = 0; i < maxChannels; i++)
			{
				GameObject channel = new GameObject ("channel" + i);
				channel.transform.SetParent (transform);

				channel.AddComponent<AudioSource> ();
				channels.Add (channel.AddComponent<AudioChannel2> ());
			}
		}

		private AudioChannel2 GetFreeChannel ()
		{
			foreach (AudioChannel2 channel in channels)
			{
				if (!channel.IsPlaying)
				{
					Debug.Log("returning empty channel");
					return channel;
				}
			}
			return null;
		}

		protected void OnEnable ()
		{
			EventManager.AddAudioListener (PlayAudio);
		}

		protected void OnDisable ()
		{
			EventManager.RemoveAudioListener (PlayAudio);
		}

		private void PlayAudio (AudioClip clip)
		{
			AudioChannel2 channel = GetFreeChannel();
			
			if(channel != null)
			{
				channel.Play(clip);
			}
			else
			{
				Debug.LogWarning("No free AudioChannels");
			}
		}



	}

}