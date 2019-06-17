/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;
using UnityEngine.UI;

public class HumanAnatomySoundManager : MonoBehaviour {

	#region Variables;
	public AudioSource audioSource;

	AudioClip thisNarratorSound;
	#endregion

	#region Methods
	public void SetSound(HumanAnatomySoundInfo _sounds)
	{
		//Play Narrator when
		audioSource.clip = _sounds.narrator;
		audioSource.Play();

		// Set Sounds to this SoundManager
		thisNarratorSound = _sounds.narrator;
	}

	public void PlayNarratorSound()
	{
		audioSource.Stop();
		audioSource.clip = thisNarratorSound;
		audioSource.Play();
	}
	#endregion
}