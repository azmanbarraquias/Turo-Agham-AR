/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;

public class AnimalInfoTrigger : MonoBehaviour {

	#region Variables
	public AnimalInfo info; // call and use variable in the Dialogue class
	#endregion

	#region Methods
	// Use this for initialization
	public void SetInfoToAnimalManager()
	{	
			FindObjectOfType<AnimalInfoManager>().StartInformation(info);
    }
	#endregion
}
