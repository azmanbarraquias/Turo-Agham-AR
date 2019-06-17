/*
* Copyright (c) Creative Code Studio
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherManager : MonoBehaviour
{

    #region Variables
    [Space]
    public Animator moody;
    public Animator sun;

    [Space]
    public Animator rainbow;
    bool isRainbow = false;

    [Space]
    public Animator groundSnowy;
    public Animator groundRainy;

    [Space]
    public Animator houseSnow;

    [Space]
    public Animator windMillTowerSnowy;
    public Animator windMillFanSpeed;

    [Space]
    public Animator[] cloudSnowy;
    public Animator[] cloudWindy;
    public Animator[] cloudRainy;

    [Space]
    public Animator menuSelectionSnow;

    [Space]
    public GameObject snowEffect;
    public GameObject rainEffect;
    public GameObject windEffect;
    public GameObject birds;

    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioClip sunnySound;
    public AudioClip rainySound;
    public AudioClip windySound;

    public AudioSource audioSourceCharacter;
    public AudioClip sunnyCSound;
    public AudioClip rainyCSound;
    public AudioClip windyCSound;
    public AudioClip snowyCSound;
    public AudioClip hello;

    [Space]
    public GameObject sunnyTxt;
    public GameObject snowyTxt;
    public GameObject windyTxt;
    public GameObject rainyTxt;
    [Space]
    public bool[] weatherUnlocked;

    public GameObject characterSun;
    public GameObject characterWind;
    public GameObject characterRain;
    public GameObject characterSnow;

    #endregion

    #region Methods

    public void Hello()
    {
        sunnyTxt.SetActive(true);
        audioSourceCharacter.clip = hello;
        audioSourceCharacter.Play();
    }

    public void Suny()
    {
        weatherUnlocked[0] = true;

        characterSun.SetActive(true);
        characterWind.SetActive(false);
        characterRain.SetActive(false);
        characterSnow.SetActive(false);


        if (IsAllMissionComplete() == true)
        {
            // AchievementManager.Instance.UnlockAchievement("Storm Breaker");
        }

        rainbow.SetBool("RainbowActive", false);

        if (isRainbow == true)
        {
            rainbow.SetBool("RainbowActive", true);
        }

        sunnyTxt.SetActive(true);
        snowyTxt.SetActive(false);
        windyTxt.SetActive(false);
        rainyTxt.SetActive(false);

        audioSourceCharacter.Stop();
        audioSourceCharacter.clip = sunnyCSound;
        audioSourceCharacter.Play();
        moody.SetBool("MoodyActive", false);
        sun.SetBool("SunDown", false);

        groundSnowy.SetBool("MountainSnowActive", false);
        groundRainy.SetBool("MountainRainyActive", false);

        houseSnow.SetBool("HouseSnowActive", false);

        windMillTowerSnowy.SetBool("WindMillHouseSnowyActive", false);
        windMillFanSpeed.SetTrigger("FanSunny");//FanSunny, FanSnowy, FanWindy, FanRainy

        foreach (Animator cSnowy in cloudSnowy)
        {
            cSnowy.SetBool("CloudSnowyActive", false);
        }
        foreach (Animator cWindy in cloudWindy)
        {
            cWindy.SetBool("CloudWindyActive", false);
        }
        foreach (Animator cRainy in cloudRainy)
        {
            cRainy.SetBool("CloudRainyActive", false);
        }

        menuSelectionSnow.SetBool("WeatherSelectionSnowyActive", false);
        snowEffect.SetActive(false);
        rainEffect.SetActive(false);
        windEffect.SetActive(false);
        birds.SetActive(true);

        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = sunnySound;
        audioSource.Play();
    }

    public void Snowy()
    {
        weatherUnlocked[1] = true;

        characterSun.SetActive(false);
        characterWind.SetActive(false);
        characterRain.SetActive(false);
        characterSnow.SetActive(true);

        if (IsAllMissionComplete() == true)
        {
            //AchievementManager.Instance.UnlockAchievement("Storm Breaker");
        }

        isRainbow = false;
        rainbow.SetBool("RainbowActive", false);

        sunnyTxt.SetActive(false);
        snowyTxt.SetActive(true);
        windyTxt.SetActive(false);
        rainyTxt.SetActive(false);

        audioSourceCharacter.Stop();
        audioSourceCharacter.clip = snowyCSound;
        audioSourceCharacter.Play();
        moody.SetBool("MoodyActive", false);
        sun.SetBool("SunDown", true);

        groundSnowy.SetBool("MountainSnowActive", true);
        groundRainy.SetBool("MountainRainyActive", false);

        houseSnow.SetBool("HouseSnowActive", true);

        windMillTowerSnowy.SetBool("WindMillHouseSnowyActive", true);
        windMillFanSpeed.SetTrigger("FanSnowy");//FanSunny, FanSnowy, FanWindy, FanRainy

        foreach (Animator cSnowy in cloudSnowy)
        {
            cSnowy.SetBool("CloudSnowyActive", true);
        }
        foreach (Animator cWindy in cloudWindy)
        {
            cWindy.SetBool("CloudWindyActive", false);
        }
        foreach (Animator cRainy in cloudRainy)
        {
            cRainy.SetBool("CloudRainyActive", false);
        }

        menuSelectionSnow.SetBool("WeatherSelectionSnowyActive", true);
        snowEffect.SetActive(true);
        rainEffect.SetActive(false);
        windEffect.SetActive(false);
        birds.SetActive(false);

        audioSource.Stop();
        //audioSource.loop = true;
        //audioSource.clip = snowySound;
        //audioSource.Play();
    }

    public void Windy()
    {

        characterSun.SetActive(false);
        characterWind.SetActive(true);
        characterRain.SetActive(false);
        characterSnow.SetActive(false);

        weatherUnlocked[2] = true;

        if (IsAllMissionComplete() == true)
        {
            //AchievementManager.Instance.UnlockAchievement("Storm Breaker");
        }

        isRainbow = false;
        rainbow.SetBool("RainbowActive", false);

        sunnyTxt.SetActive(false);
        snowyTxt.SetActive(false);
        windyTxt.SetActive(true);
        rainyTxt.SetActive(false);

        audioSourceCharacter.Stop();
        audioSourceCharacter.clip = windyCSound;
        audioSourceCharacter.Play();
        moody.SetBool("MoodyActive", false);
        sun.SetBool("SunDown", false);

        groundSnowy.SetBool("MountainSnowActive", false);
        groundRainy.SetBool("MountainRainyActive", false);

        houseSnow.SetBool("HouseSnowActive", false);

        windMillTowerSnowy.SetBool("WindMillHouseSnowyActive", false);
        windMillFanSpeed.SetTrigger("FanWindy");//FanSunny, FanSnowy, FanWindy, FanRainy

        foreach (Animator cSnowy in cloudSnowy)
        {
            cSnowy.SetBool("CloudSnowyActive", false);
        }
        foreach (Animator cWindy in cloudWindy)
        {
            cWindy.SetBool("CloudWindyActive", true);
        }
        foreach (Animator cRainy in cloudRainy)
        {
            cRainy.SetBool("CloudRainyActive", false);
        }

        menuSelectionSnow.SetBool("WeatherSelectionSnowyActive", false);
        snowEffect.SetActive(false);
        rainEffect.SetActive(false);
        windEffect.SetActive(true);
        birds.SetActive(false);

        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = windySound;
        audioSource.Play();
    }

    public void Rainy()
    {
        characterSun.SetActive(false);
        characterWind.SetActive(false);
        characterRain.SetActive(true);
        characterSnow.SetActive(false);

        weatherUnlocked[3] = true;

        if (IsAllMissionComplete() == true)
        {
            //AchievementManager.Instance.UnlockAchievement("Storm Breaker");
        }

        isRainbow = true;
        rainbow.SetBool("RainbowActive", true);

        sunnyTxt.SetActive(false);
        snowyTxt.SetActive(false);
        windyTxt.SetActive(false);
        rainyTxt.SetActive(true);

        audioSourceCharacter.Stop();
        audioSourceCharacter.clip = rainyCSound;
        audioSourceCharacter.Play();
        moody.SetBool("MoodyActive", true);
        sun.SetBool("SunDown", true);

        groundSnowy.SetBool("MountainSnowActive", false);
        groundRainy.SetBool("MountainRainyActive", true);

        houseSnow.SetBool("HouseSnowActive", false);

        windMillTowerSnowy.SetBool("WindMillHouseSnowyActive", false);
        windMillFanSpeed.SetTrigger("FanRainy");//FanSunny, FanSnowy, FanWindy, FanRainy

        foreach (Animator cSnowy in cloudSnowy)
        {
            cSnowy.SetBool("CloudSnowyActive", false);
        }
        foreach (Animator cWindy in cloudWindy)
        {
            cWindy.SetBool("CloudWindyActive", false);
        }
        foreach (Animator cRainy in cloudRainy)
        {
            cRainy.SetBool("CloudRainyActive", true);
        }
        menuSelectionSnow.SetBool("WeatherSelectionSnowyActive", false);
        snowEffect.SetActive(false);
        rainEffect.SetActive(true);
        windEffect.SetActive(false);
        birds.SetActive(false);

        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = rainySound;
        audioSource.Play();
    }

    private bool IsAllMissionComplete()
    {
        for (int i = 0; i < weatherUnlocked.Length; ++i)
        {
            if (weatherUnlocked[i] == false)
            {
                return false;
            }
        }
        return true;
    }
    #endregion
}
