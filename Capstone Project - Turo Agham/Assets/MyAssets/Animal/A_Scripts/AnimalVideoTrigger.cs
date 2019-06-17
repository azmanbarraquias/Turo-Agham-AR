/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;
using UnityEngine.Video;

public class AnimalVideoTrigger : MonoBehaviour
{
	public VideoClip videoClip = null; // the video you want to play

	public void SetAnimalVideo()
	{
		FindObjectOfType<AnimalVideoManager>().PlayVideo(videoClip);		
	}
}