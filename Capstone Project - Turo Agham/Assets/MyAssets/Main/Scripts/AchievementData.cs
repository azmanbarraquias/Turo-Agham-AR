using UnityEngine;

[System.Serializable]
public class AchievementData
{
	public string achievementList;
	public string title;
	public string description;
	public int points;
	public Sprite imageIcon;
	public string[] dependencies = null;
}
