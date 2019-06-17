/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;
using UnityEngine.UI;

public class SaveMainMenuState : MonoBehaviour {

	#region Variables
	public Button solarSystem;
	public Button animals;
	public Button weather;
	public Button humanAnatomy;

	public static bool isSolarSystemClick;
	public static bool isAnimalClick;
	public static bool isWeatherClick;
	public static bool isHumanAnatomyClick;
    [Space]

    [Header("Menu Image Button:")]
    [Space]
    public Image solarSystemBtn;
    public Sprite[] solarSytemSprites;

    public Image animalBtn;
    public Sprite[] animalSprites;

    public Image weatherBtn;
    public Sprite[] weatherSprites;

    #endregion

    #region Methods

    void Awake()
	 {
        if (isSolarSystemClick == true)
		{
			solarSystem.onClick.Invoke();
		}

		if (isAnimalClick == true)
		{
			animals.onClick.Invoke();
		}

		if (isWeatherClick == true)
		{
			weather.onClick.Invoke();
		}

		if (isHumanAnatomyClick == true)
		{
			humanAnatomy.onClick.Invoke();
		}
	 }

	public void ClickSolarSystem()
	{
		isSolarSystemClick = true;
		isAnimalClick = false;
		isWeatherClick = false;
		isHumanAnatomyClick = false;
	}
	public void ClickAnimal()
	{
		isSolarSystemClick = false;
		isAnimalClick = true;
		isWeatherClick = false;
		isHumanAnatomyClick = false;
	}
	public void ClickWeather()
	{
		isSolarSystemClick = false;
		isAnimalClick = false;
		isWeatherClick = true;
		isHumanAnatomyClick = false;
	}
	public void ClickHumanAnatomy()
	{
		isSolarSystemClick = false;
		isAnimalClick = false;
		isWeatherClick = false;
		isHumanAnatomyClick = true;
	}

    public void AchievementToggle()
    {
        GameObject Achievement = DontDistory.thisGameObjectInstance.gameObject.transform.GetChild(0).gameObject;
        Achievement.SetActive(!Achievement.activeSelf);
    }


    public int RandomBtn(int _range)
    {
       int rand = Random.Range(0, _range);
       return rand;
    }

    public void RandomSolarSystemIMG()
    {
        int rand = RandomBtn(solarSytemSprites.Length);
        solarSystemBtn.sprite = solarSytemSprites[rand];
    }

    public void AnimalIMG()
    {
        int rand = RandomBtn(animalSprites.Length);
        animalBtn.sprite = animalSprites[rand];
    }

    public void Weather()
    {
        int rand = RandomBtn(weatherSprites.Length);
        weatherBtn.sprite = weatherSprites[rand];
    }
    #endregion
}