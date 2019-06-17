using UnityEngine;
using UnityEngine.UI;

public class AchievementButton : MonoBehaviour
{
	public GameObject achievementList; // AchievementList

	public Sprite neutral, highlight;

	private Image imgSprite;

	void Awake()
	{
		// Get the image component this script attach to.
		imgSprite = GetComponent<Image>();
	}

	public void Click()
	{
		if (imgSprite.sprite == neutral)
		{
			imgSprite.sprite = highlight;
			achievementList.SetActive(true);
		}
		else
		{
			imgSprite.sprite = neutral;
			achievementList.SetActive(false);
		}
	}
}
