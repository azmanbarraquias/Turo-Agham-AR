/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;

public class PlanetSetInfo : MonoBehaviour {

	#region Variables
	public PlanetInfo info; // call and use variable in the Dialogue class
	public bool offThisButton;
	#endregion

	#region Methods
	// Use this for initialization
	public void SetPlanetInfo()
	{
		FindObjectOfType<PlanetInfoManager>().StartInformation(info);
		if (offThisButton == true)
		{
			this.gameObject.SetActive(false);
		}
	}
	#endregion
}