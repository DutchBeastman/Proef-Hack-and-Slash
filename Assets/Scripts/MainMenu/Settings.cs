//Created By: Jeremy Bond
//Date: 

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

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

	protected void Update ()
	{
		if (lastMasterVolume != masterVolume.value)
		{
			ChangeMasterVolume();
		}
		else if(lastSFXVolume != SFXVolume.value)
		{
			ChangeSFXVolume();
		}
		else if (lastMusicVolume != musicVolume.value)
		{
			ChangeMusicVolume();
		}
		else if (!afterSoundPlayed)
		{
			afterSoundPlayed = true;
			EventManager.TriggerAudioSFXEvent (volumeChangedSound);
		}
	}

	private void ChangeMasterVolume ()
	{
		lastMasterVolume = masterVolume.value;
		AudioListener.volume = masterVolume.value;
		mixer.SetFloat ("MixerMasterVolume", masterVolume.value);
		afterSoundPlayed = false;
	}

	private void ChangeSFXVolume ()
	{
		lastSFXVolume = SFXVolume.value;
		AudioListener.volume = SFXVolume.value;
		mixer.SetFloat ("MixerSFXVolume", SFXVolume.value);
		afterSoundPlayed = false;
	}

	private void ChangeMusicVolume ()
	{
		lastMusicVolume = musicVolume.value;
		AudioListener.volume = musicVolume.value;
		mixer.SetFloat ("MixerMusicVolume", musicVolume.value);
		afterSoundPlayed = false;
	}
}
