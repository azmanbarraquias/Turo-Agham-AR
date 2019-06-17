using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement
{
	#region My Variable
	private string name;
	public string Name
	{
		get { return name; }
		set { name = value; }
	}

	private string description;
	public string Description
	{
		get { return description; }
		set { description = value; }
	}

	private int points;
	public int Points
	{
		get { return points; }
		set { points = value; }
	}

	private Sprite achievementIcon;
	public Sprite AchievementIcon
	{
		get { return achievementIcon; }
		set { achievementIcon = value; }
	}

	private GameObject achievementRef;

	private List<Achievement> dependencies = new List<Achievement>();
	public List<Achievement> Dependencies
	{
		 get { return dependencies; }
		 set { dependencies = value; }
	}

	private string child;
	public string Child
	{
		get { return child; }
		set { child = value; }
	}

	private bool unlocked;
	public bool Unlocked
	{
		get { return unlocked; }
		set { unlocked = value; }
	}

	public Achievement(string _name, string _description, int _points, Sprite _achievementIcon, GameObject _achievementRef)
	{
		this.Name = _name;
		this.Description = _description;
		this.points = _points;
		this.achievementIcon = _achievementIcon;
		this.achievementRef = _achievementRef;

		this.unlocked = false;

		LoadAchievement();
	}

	public bool EarnAchievement()
	{
		if (!unlocked && (!Dependencies.Exists(x => x.unlocked == false))) // unlock != false
		{
			achievementRef.GetComponent<Image>().sprite = AchievementManager.Instance.unlockedSprite;
			SaveAchievement(true);

			if (Child !=null)
			{
				AchievementManager.Instance.EarnAchievement(Child);
			}

			return true; 
		}
		else
		{
			return false;
		}
	}
	#endregion

	public void SaveAchievement(bool value)
	{
		unlocked = value;

		int tempPoints = PlayerPrefs.GetInt("Points");

		PlayerPrefs.SetInt("Points", tempPoints += points);

		PlayerPrefs.SetInt(name, value ? 1 : 0);

		PlayerPrefs.Save();
	}

	public void LoadAchievement()
	{
		unlocked = PlayerPrefs.GetInt(name) == 1 ? true : false;

		if (unlocked)
		{
			AchievementManager.Instance.pointsTMP.text = "Points: " + PlayerPrefs.GetInt("Points");

			achievementRef.GetComponent<Image>().sprite = AchievementManager.Instance.unlockedSprite;
		}
	}

	public void AddDependency(Achievement _dependency)
	{
		Dependencies.Add(_dependency);
	}
}