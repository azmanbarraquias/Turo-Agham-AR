/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;
using Vuforia;

public class WeatherVirtualButtons : MonoBehaviour, IVirtualButtonEventHandler {

	#region MyVariable
	[Header("Weather")]
	public Transform[] sunnyObject;
	public Transform[] rainingObject;
    public Transform[] snowingObject;
    public Transform[] windyObject;
    public Animator rainbow;

    public AudioSource audioSource;

	public AudioClip sunnySoundEffect;
	public AudioClip rainingSoundEffect;
    public AudioClip snowingSoundEffect;
    public AudioClip windySoundEffect;

    public GameObject stageModel;
    public GameObject rModel;

    Renderer stageTexture;
    public Material Mat1, Mat2;

    Renderer SnowstageTexture;
    public Material SMat1, SMat2;
    #endregion

    void Start()
	{
        rainbow.SetBool("isSunny", true);
        stageTexture = stageModel.GetComponent<Renderer>();
        SnowstageTexture = rModel.GetComponent<Renderer>();

        // Single Button
        // vrb = GetComponentInChildren<VirtualButtonBehaviour>();
        // vrb.RegisterEventHandler(this);

        // Multiple Button
        VirtualButtonBehaviour[] vrb = GetComponentsInChildren<VirtualButtonBehaviour>();
		for (int i = 0; i < vrb.Length; i++)
		{
			vrb[i].RegisterEventHandler(this);
		}
	}

	public void OnButtonPressed(VirtualButtonBehaviour vb)
	{
		if (vb.VirtualButtonName == "VButton1")
		{
            //Sunny
            OffRainy();
			OffSnowy();
			OffWindy();

            AchievementManager.Instance.UnlockAchievement("Weather Bender");

            audioSource.Stop();
            audioSource.clip = sunnySoundEffect;
            audioSource.Play();

            rainbow.SetBool("isSunny", true);

            SnowstageTexture.material = SMat1;
            stageTexture.material = Mat1;

            foreach (Transform sunObject in sunnyObject)
            {
                sunObject.gameObject.SetActive(true);
            }
		}
		else if (vb.VirtualButtonName == "VButton2")
		{
			OffRainy();
			OffWindy();
			OffSunny();
            //Snow

            AchievementManager.Instance.UnlockAchievement("Weather Bender");

            stageTexture.material = Mat2;
            SnowstageTexture.material = SMat2;
            audioSource.Stop();
			audioSource.clip = snowingSoundEffect;
			audioSource.Play();
            rainbow.SetBool("isSunny", false);

            foreach (Transform snowObject in snowingObject)
            {
                snowObject.gameObject.SetActive(true);
            }
        }
		else if (vb.VirtualButtonName == "VButton3")
		{
			OffRainy();
			OffSnowy();
			OffSunny();

            AchievementManager.Instance.UnlockAchievement("Weather Bender");

            audioSource.Stop();
            stageTexture.material = Mat1;
            SnowstageTexture.material = SMat1;
            audioSource.clip = windySoundEffect;
			audioSource.Play();
            rainbow.SetBool("isSunny", false);

            foreach (Transform windObject in windyObject)
            {
                windObject.gameObject.SetActive(true);
            }
        }
        else if (vb.VirtualButtonName == "VButton4")
		{
			OffSnowy();
			OffWindy();
			OffSunny();

            AchievementManager.Instance.UnlockAchievement("Weather Bender");


            rainbow.SetBool("isSunny", false);

            stageTexture.material = Mat1;
            SnowstageTexture.material = SMat1;

            audioSource.Stop();
            audioSource.clip = rainingSoundEffect;
            audioSource.Play();

            foreach (Transform rainObject in rainingObject)
            {
                rainObject.gameObject.SetActive(true);
            }
        }
        else
		{
			throw new UnityException(vb.VirtualButtonName + " Virtual Button Not Supported");
		}
	}

	public void OnButtonReleased(VirtualButtonBehaviour vb)
	{
		if (vb.VirtualButtonName == "VButton1")
		{
           // Release();
        }
		else if (vb.VirtualButtonName == "VButton2")
		{
           // Release();
        }
		else if (vb.VirtualButtonName == "VButton3")
		{
           // Release();
        }
        else if (vb.VirtualButtonName == "VButton4")
        {
           // Release();
        }
        else
		{
            throw new UnityException(vb.VirtualButtonName + " Virtual Button Not Supporte - Release");
        }
	}

	public void Release()
	{
		//audioSource.Stop();
		stageTexture.material = Mat1;
		SnowstageTexture.material = SMat1;
		rainbow.SetBool("isSunny", false);

		foreach (Transform sunObject in sunnyObject)
		{
			sunObject.gameObject.SetActive(false);
		}
		foreach (Transform snowObject in snowingObject)
		{
			snowObject.gameObject.SetActive(false);
		}
		foreach (Transform windObject in windyObject)
		{
			windObject.gameObject.SetActive(false);
		}
		foreach (Transform rainObject in rainingObject)
		{
			rainObject.gameObject.SetActive(false);
		}
	}

	public void OffSunny()
	{
		stageTexture.material = Mat1;
		SnowstageTexture.material = SMat1;
		foreach (Transform sunObject in sunnyObject)
		{
			sunObject.gameObject.SetActive(false);
		}
	}

	public void OffSnowy()
	{
		foreach (Transform snowObject in snowingObject)
		{
			rainbow.SetBool("isSunny", false);
			snowObject.gameObject.SetActive(false);
		}
	}

	public void OffWindy()
	{
		rainbow.SetBool("isSunny", false);
		stageTexture.material = Mat1;
		SnowstageTexture.material = SMat1;
		foreach (Transform windObject in windyObject)
		{
			windObject.gameObject.SetActive(false);
		}
	}

	public void OffRainy()
	{
		rainbow.SetBool("isSunny", false);
		stageTexture.material = Mat1;
		SnowstageTexture.material = SMat1;
		foreach (Transform rainObject in rainingObject)
		{
			rainObject.gameObject.SetActive(false);
		}
	}
}
