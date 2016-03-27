//Created By: Jeremy Bond
//Date: 25/03/2016

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using Utils;

public class EventManager : MonoBehaviour
{

	private Dictionary<string, UnityEvent> eventDictionary;
	private Dictionary<string, AudioEvent> audioEventDictionary;

	private static EventManager eventManager;
	private const string AUDIOEVENT = "audioEvent";

	public static EventManager instance
	{
		get
		{
			if (!eventManager)
			{
				eventManager = FindObjectOfType (typeof (EventManager)) as EventManager;

				if (!eventManager)
				{
					Debug.LogError ("There needs to be one active EventManager script on a GameObject in your scene.");
				}
				else
				{
					eventManager.Init ();
				}
			}

			return eventManager;
		}
	}

	private void Init ()
	{
		if (eventDictionary == null)
		{
			eventDictionary = new Dictionary<string, UnityEvent> ();
		}
		if(audioEventDictionary == null)
		{
			audioEventDictionary = new Dictionary<string, AudioEvent>();
		}
	}

	public static void AddListener (string eventName, UnityAction listener)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.AddListener (listener);
		}
		else
		{
			thisEvent = new UnityEvent ();
			thisEvent.AddListener (listener);
			instance.eventDictionary.Add (eventName, thisEvent);
		}
	}

	public static void AddAudioListener (UnityAction<AudioClip> listener)
	{
		AudioEvent thisEvent = null;
		if (instance.audioEventDictionary.TryGetValue (AUDIOEVENT, out thisEvent))
		{
			thisEvent.AddListener (listener);
		}
		else
		{
			thisEvent = new AudioEvent ();
			thisEvent.AddListener (listener);
			instance.audioEventDictionary.Add (AUDIOEVENT, thisEvent);
		}
	}

	public static void RemoveListener (string eventName, UnityAction listener)
	{
		if (eventManager == null)
		{
			return;
		}
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}

	public static void RemoveAudioListener (UnityAction<AudioClip> listener)
	{
		if (eventManager == null)
		{
			return;
		}
		AudioEvent thisEvent = null;
		if (instance.audioEventDictionary.TryGetValue (AUDIOEVENT, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}

	public static void TriggerEvent (string eventName)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke ();
		}
	}

	public static void TriggerAudioEvent (AudioClip clip)
	{
		AudioEvent thisEvent = null;
		if (instance.audioEventDictionary.TryGetValue (AUDIOEVENT, out thisEvent))
		{
			thisEvent.Invoke (clip);
		}
	}

}











