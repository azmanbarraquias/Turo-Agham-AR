/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class AnimalReset : MonoBehaviour
{
    #region Variables
    public TextMeshProUGUI resetName;
    public TextMeshProUGUI resetDisciption;
    public TextMeshProUGUI[] moreTMP;

    public Transform ModelHolder;

    public AudioSource audioToStop;

    GameObject stage;

    Quaternion originalRotation;

    AnimalInfoManager animalInfo;

    public RawImage rawImage; // Raw Image we want to make a video texture output

    public VideoPlayer videoPlayer; // the component of videoplayer

    public AudioSource audioSource; // videoplayer audio out put sourd
    public AudioSource audioSourceV;

    public GameObject animator;

    public Animator animalInfoAnim;
    public Animator stageAnim;
    [Space]
    public GameObject[] animalLandBtn;
    public GameObject[] animalWaterBtn;
    public GameObject[] animalSkyBtn;
    [Space]
    public Transform animalSelection;
    [Space]
    public GameObject[] InfoContent;
    public GameObject activeInfoMenuBtn;
    public Scrollbar scrollbar;
    #endregion

    #region Methods
    void Start()
    {
        originalRotation = ModelHolder.transform.localRotation;
        stage = ModelHolder.gameObject;
    }

    public void InfoContentReset()
    {
        activeInfoMenuBtn.SetActive(true);
        foreach (GameObject content in InfoContent)
        {
            content.SetActive(false);
        }
    }

    public void BackToAnimalSelection()
    {
        InfoContentReset();
        // Back to normal rotation
        stage.transform.rotation = originalRotation;

        // Stop all Audio
        audioToStop.Stop();

        //Reset Text UI
        resetName.text = "";
        resetDisciption.text = "";
        foreach (var tmp in moreTMP)
        {
            tmp.text = "";
        }

        //Set Active false all model in ModelHolders
        foreach (Transform model in ModelHolder)
        {
            model.gameObject.SetActive(false);
        }

        //animalInfo.StopDisplayText();

        rawImage.texture = null;
        videoPlayer.clip = null;
        audioSourceV = null;
        StopSound();
        StopVideo();
        animator.GetComponent<Animator>().enabled = false;
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
    }

    public void StopSound()
    {
        audioSource.Stop();
    }

    public void ShowAnimalInfo()
    {
        animalInfoAnim.SetBool("ShowInfo", true);

        stageAnim.SetBool("StageMove", true);
    }

    public void hideAnimalInfo()
    {
        animalInfoAnim.SetBool("ShowInfo", false);

        stageAnim.SetBool("StageMove", false);
    }

    public void SkyAnimal()
    {
        scrollbar.value = 1;
        foreach (var animalbtn in animalSkyBtn)
        {
            animalbtn.SetActive(true);
        }

        foreach (var animalbtn in animalLandBtn)
        {
            animalbtn.SetActive(false);
        }

        foreach (var animalbtn in animalWaterBtn)
        {
            animalbtn.SetActive(false);
        }
    }

    public void ResetAnimalFilter()
    {
        scrollbar.value = 1;

        foreach (Transform animal in animalSelection)
        {
            animal.gameObject.SetActive(true);
        }
    }

    public void LandAnimal()
    {
        scrollbar.value = 1;

        foreach (var animalbtn in animalLandBtn)
        {
            animalbtn.SetActive(true);
        }

        foreach (var animalbtn in animalSkyBtn)
        {
            animalbtn.SetActive(false);
        }

        foreach (var animalbtn in animalWaterBtn)
        {
            animalbtn.SetActive(false);
        }
    }

    public void WaterAnimal()
    {
        scrollbar.value = 1;

        foreach (var animalbtn in animalWaterBtn)
        {
            animalbtn.SetActive(true);
        }
        foreach (var animalbtn in animalLandBtn)
        {
            animalbtn.SetActive(false);
        }

        foreach (var animalbtn in animalSkyBtn)
        {
            animalbtn.SetActive(false);
        }
    }
    #endregion
}