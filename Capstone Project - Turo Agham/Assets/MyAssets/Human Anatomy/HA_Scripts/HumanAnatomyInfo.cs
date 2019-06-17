/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;

// We want to using this Dialogue class as and object to pass on to the DialogueManager

// The Serializable attribute lets you embed a class with sub properties in the inspector.
[System.Serializable]
public class HumanAnatomyInfo
{
	#region Variables
	[Header("Information")]
	public string name; //NPC Name

	[Space]
	[TextArea(3, 10)] // Attribute to make a string be edited with a height-flexible and scrollable text area.
	public string[] descriptions;

	public Sprite partIMG;
	#endregion
}