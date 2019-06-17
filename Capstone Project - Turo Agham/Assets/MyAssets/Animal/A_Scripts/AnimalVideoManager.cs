/*
* Copyright (c) Creative Code Studio
*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AnimalVideoManager : MonoBehaviour {

	public RawImage rawImage; // Raw Image we want to make a video texture output
	public GameObject videoBtn;
	public GameObject playIcon;
	public VideoPlayer videoPlayer; // the component of videoplayer
	private VideoSource videoSource; // type of videoSource

	public AudioSource audioSource; // videoplayer audio out put sour

	private bool isPaused = true;

	public void PlayVideo(VideoClip _videoToPlay)
	{
		if (_videoToPlay == null)
		{
			videoBtn.SetActive(false);
			Debug.Log("No Video");
			return;
		}
		else
		{
			videoBtn.SetActive(true);
			StartCoroutine(SetPlayVideo(_videoToPlay));
		}
	}

	IEnumerator SetPlayVideo(VideoClip _videoToPlay)
	{
			//Set Audio Output to AudioSource
			videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

			videoPlayer.playOnAwake = false;
			audioSource.playOnAwake = false;
			audioSource.Pause();

			//Assign the Audio from Video to AudioSource to be played
			videoPlayer.EnableAudioTrack(0, true);
			videoPlayer.SetTargetAudioSource(0, audioSource);

			//Set video To Play then prepare Audio to prevent Buffering
			videoPlayer.clip = _videoToPlay;

			videoPlayer.Prepare();
			//Wait until video is prepared
			while (!videoPlayer.isPrepared)
			{
				yield return null;
			}
			Debug.Log("Done Preparing Video");

			//Assign the Texture from Video to RawImage to be displayed
			rawImage.texture = videoPlayer.texture;

			//Play Video
			videoPlayer.Pause();

			Debug.Log("Playing Video");
			while (videoPlayer.isPlaying)
			{
				Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
				yield return null;
			}
			Debug.Log("Done Playing Video");
	}

	public void PlayPause()
	{
		if (isPaused == true)
		{
			videoPlayer.Play();
			isPaused = false;
		}
		else 
		{
			videoPlayer.Pause();
			isPaused = true;
		}
	}
	public void PauseVideo()
	{
		videoPlayer.Pause();
		isPaused = true;
	}
}