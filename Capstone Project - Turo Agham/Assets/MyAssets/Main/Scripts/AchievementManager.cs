using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class AchievementManager : MonoBehaviour
{
	public GameObject achievementPrefab; // The achievement template

	public GameObject achievementMenu;

	private AchievementButton activeButton;

	public ScrollRect scrollRect;

	public GameObject visualAchievement;

	public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

	public Sprite unlockedSprite;

	public TextMeshProUGUI pointsTMP;

	private int fadeTime = 2;

	public AchievementData[] solarSystemAchievement;
	public AchievementData[] animalAchievement;
	public AchievementData[] weatherAchievement;
	public AchievementData[] humanAnatomyAchievement;

	// Singleton
	private static AchievementManager instance;
	public static AchievementManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<AchievementManager>();
			}
			return AchievementManager.instance;
		}
	}

	void Awake()
	{
		achievementMenu.SetActive(true);

		PlayerPrefs.DeleteAll(); //remember to temove
		// Example
		
		// set the first achievement which is the General Buttons when game start
		activeButton = GameObject.Find ("A_SolarSystemBtn").GetComponent<AchievementButton>();

		// Load sample Achievement to General
		// CreateAchievement([],[],[],[])
		foreach (AchievementData data in solarSystemAchievement)
		{
			CreateAchievement(data.achievementList, data.title, data.description,
								data.points, data.imageIcon, data.dependencies);
		}
		foreach (AchievementData data in animalAchievement)
		{
			CreateAchievement(data.achievementList, data.title, data.description,
								data.points, data.imageIcon, data.dependencies);
		}
		foreach (AchievementData data in weatherAchievement)
		{
			CreateAchievement(data.achievementList, data.title, data.description,
								data.points, data.imageIcon, data.dependencies);
		}
		foreach (AchievementData data in humanAnatomyAchievement)
		{
			CreateAchievement(data.achievementList, data.title, data.description,
								data.points, data.imageIcon, data.dependencies);
		}

		//CreateAchievement("General", "Press S", "Press S to earn", 20, 0);
		//CreateAchievement("General", "All Keys", "Press All Keys to unlock", 30, 0, new string[] { "Press W","Press S"});

		// Load sample Achievement to Other achievement
		//CreateAchievement("Other", "Play Game", "Quest open the game", Random.Range(1, 101), 0);

		// after we add the achievement
		GameObject[] allAchievementList = GameObject.FindGameObjectsWithTag("AchievementList");
		foreach (GameObject achievementList in allAchievementList)
		{
			achievementList.SetActive(false);
		}

		// active the first achievement the general achievement
		activeButton.Click();

		// When game start the achivement menu hide
		achievementMenu.SetActive(false);
	}

	public void OpenAchievement()
	{
		achievementMenu.SetActive(!achievementMenu.activeSelf);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			OpenAchievement();
			// disable and enable
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			EarnAchievement("Press A");
		}

		if (Input.GetKeyDown(KeyCode.W))
		{
			EarnAchievement("Press W");
		}

		if (Input.GetKeyDown(KeyCode.J))
		{
			EarnAchievement("Press J");
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			EarnAchievement("Press K");
		}

		if (Input.GetKeyDown(KeyCode.L))
		{
			EarnAchievement("Press L");
		}
	}

	public void EarnAchievement(string _title)
	{
		if (achievements[_title].EarnAchievement())
		{
			GameObject achievement = Instantiate(visualAchievement);
			SetAchievementInfo("AchievementEarn", achievement, _title);
			pointsTMP.text = "Points: " + PlayerPrefs.GetInt("Points");
			StartCoroutine(FadeAchievement(achievement));
		}
	}

	public IEnumerator HideAchievement(GameObject _achievement)
	{
		yield return new WaitForSeconds(3);
		Destroy(_achievement);
	}

	// Create or instantiate achievement template prefabs
	public void CreateAchievement(string _parent, string _title, string _description, 
						int _points, Sprite _achievementIcon, string[] _dependencies = null)
	{
		// Instatiate new gameobject store it to the achievment GameObject variable
		GameObject achievement = (GameObject)Instantiate(achievementPrefab);

		Achievement newAchievement = new Achievement(_title, _description, _points, _achievementIcon, achievement);
		achievements.Add(_title, newAchievement);

		// After we instatiate we want to set the info to that achievement
		SetAchievementInfo(_parent, achievement, _title);

		if ( _dependencies !=null )
		{
			foreach (string achievementTitle in _dependencies)
			{
				Achievement dependency = achievements[achievementTitle];
				dependency.Child = _title;
				newAchievement.AddDependency(dependency);

				// Dependency = Press Space <-- Child = Press W
				// NewAchievement = Press W --> Press Space
			}
		}
	}

	public void SetAchievementInfo(string _parent, GameObject _achievement, string _title)
	{
		// This set new achievment gameobject to parent(content)
		_achievement.transform.SetParent(GameObject.Find(_parent).transform);

		// This fix the scale problem when parenting
		_achievement.transform.localScale = new Vector3(1, 1, 1);

		// Set content coresponding to arrangement
		_achievement.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _title;
		_achievement.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = achievements[_title].Description;
		_achievement.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = achievements[_title].Points.ToString();
		_achievement.transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = achievements[_title].AchievementIcon; // same as GCIC
	}

	// This will be call when we press button
	public void ChangeCategory(GameObject _button)
	{
		AchievementButton achievementButton = _button.GetComponent<AchievementButton>();

		// Change the scrollRect
		scrollRect.content = achievementButton.achievementList.GetComponent<RectTransform>();

		achievementButton.Click();

		// click the last achievement
		activeButton.Click();

		// then we want to set the activeButton to the current achievementButton
		activeButton = achievementButton;
	}

	private IEnumerator FadeAchievement(GameObject achievement)
	{
		CanvasGroup canvasGroup = achievement.GetComponent<CanvasGroup>();

		float rate = 1.0f / fadeTime;

		int startAlpha = 0;
		int endAlpha = 1;
	
		for (int i = 0; i < 2; i++)
		{
			float progress = 0.0f;

			while (progress < 1.0)
			{
				canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, progress);

				progress += rate * Time.deltaTime;

				yield return null;
			}
			yield return new WaitForSeconds(2);
			startAlpha = 1;
			endAlpha = 0;
		}
		Destroy(achievement);
	}
    public void UnlockAchievement(string achievementName)
    {
        EarnAchievement(achievementName);
    }
}