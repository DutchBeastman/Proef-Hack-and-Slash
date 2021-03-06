﻿//Created By: Jeremy Bond
//Date: 29/03/2016

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

enum LastChangedAudioMixer
{
	Master,
	SFX,
	Music
}

public class Settings : MonoBehaviour
{
	[SerializeField] private AudioMixer mixer;
	[SerializeField] private Slider masterVolume;
	[SerializeField] private Slider SFXVolume;
	[SerializeField] private Slider musicVolume;

	[SerializeField] private AudioClip volumeChangedSound;

	private bool afterSoundPlayed = true;
	private float lastMasterVolume;
	private float lastSFXVolume;
	private float lastMusicVolume;
	private float startingVolume = 0.5f;
	
	private LastChangedAudioMixer lastChangedMixer;

	protected void Awake ()
	{
		masterVolume.value = startingVolume;
		SFXVolume.value = startingVolume;
		musicVolume.value = startingVolume;
	}

	protected void Update ()
	{
		if (lastMasterVolume != masterVolume.value)
		{
			lastMasterVolume = masterVolume.value; 
			ChangeMixerVolume (masterVolume, "MixerMasterVolume", LastChangedAudioMixer.Master);
		}
		else if(lastSFXVolume != SFXVolume.value)
		{
			lastSFXVolume = SFXVolume.value;
			ChangeMixerVolume (SFXVolume, "MixerSFXVolume", LastChangedAudioMixer.SFX);
		}
		else if (lastMusicVolume != musicVolume.value)
		{
			lastMusicVolume = musicVolume.value;
			ChangeMixerVolume(musicVolume, "MixerMusicVolume", LastChangedAudioMixer.Music);
		}
		if (!afterSoundPlayed && Input.GetMouseButtonUp(0))
		{
			afterSoundPlayed = true;
			switch (lastChangedMixer)
			{
				case LastChangedAudioMixer.Master:
					EventManager.TriggerAudioSFXEvent (volumeChangedSound);
				break;
				case LastChangedAudioMixer.SFX:
					EventManager.TriggerAudioSFXEvent (volumeChangedSound);
				break;
				case LastChangedAudioMixer.Music:
					EventManager.TriggerAudioMusicEvent (volumeChangedSound);
				break;
			}
		}
	}

	private void ChangeMixerVolume (Slider mixerVolume, string mixerName, LastChangedAudioMixer lastChangedAudioMixer)
	{
		AudioListener.volume = mixerVolume.value;
		mixer.SetFloat (mixerName, mixerVolume.value);

		lastChangedMixer = lastChangedAudioMixer;
		afterSoundPlayed = false;
	}
}
