/*
* Copyright (c) Creative Code Studio
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetSettingManager : MonoBehaviour {

	#region Variables
	public PlanetRotateSetting[] numberOfPlanets;
	#endregion

	#region Methods

	// Update is called once per frame
	void Update () 
	{
		foreach (PlanetRotateSetting planet in numberOfPlanets)
		{
			// RotateAround takes three arguments, first is the Vector to rotate around
			// second is a vector that axis to rotate around
			// third is the degrees to rotate, in this case the speed per second
			planet.thePlanet.transform.RotateAround(planet.targetRotateAround.position, planet.targetRotateAround.up, planet.speedRotateAround * Time.deltaTime);

			planet.thePlanet.transform.Rotate(0, planet.planetRotation * Time.deltaTime, 0);
		}
		
	}
	#endregion
}
