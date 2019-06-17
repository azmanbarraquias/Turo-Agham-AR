/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioControl : MonoBehaviour {

	#region Variables
	public AudioSource[] audioSourceScene;
	private static float audioVolume = 0.8f;
	public Slider volumeSlider;
    public TextMeshProUGUI volumeTMP;
	#endregion

	#region Methods
	
	void Awake()
	{
		if (volumeSlider != null)
		{
			volumeSlider.value = audioVolume;
        }
	}

	void Update () 
	{
		foreach (var item in audioSourceScene)
		{
			item.volume = audioVolume;

            if (volumeTMP != null)
            {
                volumeTMP.text = (audioVolume * 100).ToString("0");
            }
        }
	}

	public void SetVolume(float _vol)
	{
		audioVolume = _vol;
	}
	#endregion
}
