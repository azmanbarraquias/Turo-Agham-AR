/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;

public class AnimalSoundTrigger : MonoBehaviour {

	#region Variables
	public AnimalSoundInfo sounds;
	#endregion

	#region Methods
	public void SetAnimalSound()  // So this script attached to the button and will be call this fuction if pressed
	{
		FindObjectOfType<AnimalSoundManager>().SetSound(sounds);
	}
	#endregion
}
