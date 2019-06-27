using UnityEngine;

[System.Serializable]
public class TF_Question 
{

	[Header("Question")]
	public string question;

	[Space]
	public bool isTrue;

	[Space]
	public bool isFalse;

    public AudioClip questionSound;

    public Sprite questionImage;
}
