/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;

[System.Serializable]
public class AnimalSoundInfo
{
	#region Variables
	[Header("Sound Clip")]
	public bool animalHasSound;
	public AudioClip discription;
	public AudioClip whatDoTheyEatAClip;
	public AudioClip howDoTheyHuntAClip;
	public AudioClip[] facts;
	#endregion
}