/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;

public class HumanAnatomySetSoundInfo : MonoBehaviour {

	#region Variables
	public HumanAnatomySoundInfo sounds;
	#endregion

	#region Methods
	public void SetSound()  // So this script attached to the button and will be call this fuction if pressed
	{
		if (sounds == null)
		{
			Debug.Log("No Sound");
			return;
		}
		FindObjectOfType<HumanAnatomySoundManager>().SetSound(sounds);
	}
	#endregion
}
