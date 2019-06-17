/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;

public class HumanAnatomySetInfo : MonoBehaviour {

	#region Variables
	public HumanAnatomyInfo info; // call and use variable in the Dialogue class
	#endregion

	#region Methods
	// Use this for initialization
	public void SetInfoToHumanAnatomyInfoManager()
	{
		FindObjectOfType<HumanAnatomyInfoManager>().StartInformation(info);
	}
	#endregion
}