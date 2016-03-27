using System.Collections;
using UnityEngine;

namespace Utils
{
	public class AudioObjectMultiple : AudioObject
	{
		[SerializeField] private AudioObjectSingle[] available;

		public AudioObjectSingle Next()
		{
			return available[Random.Range(0, available.Length)];
		}
	}
}
