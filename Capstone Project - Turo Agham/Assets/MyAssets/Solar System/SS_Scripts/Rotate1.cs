/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;

public class Rotate1 : MonoBehaviour {

	#region Variables
	public float rotateSpeed = 30f;
	#endregion

	#region Methods
	void Update () 
	{
		this.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
	}
	#endregion
}