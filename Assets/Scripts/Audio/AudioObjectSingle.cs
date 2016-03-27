using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace Utils
{
	public class AudioObjectSingle : AudioObject
	{
		[SerializeField] private AudioClip audioClip;
		[SerializeField] private AudioMixerGroup audioMixerGroup;

		[SerializeField, Range( 0, 1)] private float volume = 1;
		[SerializeField, Range(-3, 3)] private float pitch = 1;
		[SerializeField, Range(-1, 1)] private float stereoPan;
		[SerializeField, Range( 0, 1)] private float spatialBlend;
		[SerializeField, Range( 0, 1.1f)] private float reverbZoneMix = 1;

		[SerializeField, Range(0, 5)] private float dopplerLevel = 1;
		[SerializeField, Range(0, 360)] private float spread;
		[SerializeField] private float minDistance = 1;
		[SerializeField] private float maxDistance = 500;

		[SerializeField] private AudioRolloffMode rolloffMode = AudioRolloffMode.Logarithmic;

		[SerializeField] private bool bypassEffects;
		[SerializeField] private bool bypassListenerEffects;
		[SerializeField] private bool bypassReverbZones;

		internal void ApplySettings(AudioSource audioSource)
		{
			audioSource.clip = audioClip;
			audioSource.outputAudioMixerGroup = audioMixerGroup;

			audioSource.volume = volume;
			audioSource.pitch = pitch;
			audioSource.panStereo = stereoPan;
			audioSource.spatialBlend = spatialBlend;
			audioSource.reverbZoneMix = reverbZoneMix;

			audioSource.dopplerLevel = dopplerLevel;
			audioSource.spread = spread;
			audioSource.minDistance = minDistance;
			audioSource.maxDistance = maxDistance;

			audioSource.rolloffMode = rolloffMode;

			audioSource.bypassEffects = bypassEffects;
			audioSource.bypassListenerEffects = bypassListenerEffects;
			audioSource.bypassReverbZones = bypassReverbZones;
		}
	}
}
