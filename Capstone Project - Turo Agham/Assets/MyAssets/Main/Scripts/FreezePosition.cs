/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;

public class FreezePosition : MonoBehaviour {

	#region Variables
	private Vector3 freezePosition;
	#endregion
	
	#region Methods
	// Use this for initialization
	void Start () 
	{
		// When start the game save the position
		freezePosition = this.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		// Set the position to the last save position
		this.transform.position = freezePosition;
	}
	#endregion
}
