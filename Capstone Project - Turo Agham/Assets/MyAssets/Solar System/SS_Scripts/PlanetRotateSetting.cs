/*
* Copyright (c) Creative Code Studio
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlanetRotateSetting
{
	#region Variables
	[Header("Planet Setting")]
	public GameObject thePlanet;
	public Transform targetRotateAround; // the object to rotate around
	public float speedRotateAround = 5f; // the speed of rotation
	public float planetRotation = 5f;
	#endregion
}
