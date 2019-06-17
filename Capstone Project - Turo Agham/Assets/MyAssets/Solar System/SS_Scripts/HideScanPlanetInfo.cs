/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;


public class HideScanPlanetInfo : MonoBehaviour {

	#region Variables
	public GameObject[] planetInfo;
	#endregion
	
	#region Methods
	public void PlanetInfoOn()
	{
		foreach (GameObject item in planetInfo)
		{
			item.SetActive(true);
		}
	}
	public void PlanetInfoOff()
	{
		foreach (GameObject item in planetInfo)
		{
			item.SetActive(false);
		}
	}
	#endregion
}