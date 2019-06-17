/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;

public class SolarSystemSoundTrigger : MonoBehaviour {

	#region Variables
	public SolarSystemSoundInfo sounds;
	#endregion

	#region Methods
	public void SetPlanetNarrator()  // So this script attached to the button and will be call this fuction if pressed
	{
		FindObjectOfType<SolarSystemSoundManager>().SetSound(sounds);
	}
	#endregion
}