/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;

public class RhinoDistanceEffect : MonoBehaviour
{

	#region Variables
	public GameObject thisModel;
	public GameObject targetModel;
	public GameObject canvasImage;
	public Animator modelAnimation;
	#endregion

	void Update()
	{
		float distance = Vector3.Distance(thisModel.transform.position, targetModel.transform.position);

		if (distance > 10)
		{
			canvasImage.SetActive(false);
			modelAnimation.SetBool("RhinoAttack", false);
			//Debug.Log("Out");
		}
		if (10 <= distance && distance < 13)
		{
			modelAnimation.SetBool("RhinoAttack", false);
			//Debug.Log("Level 1");
		}
		if (8 <= distance && distance < 10)
		{
			modelAnimation.SetBool("RhinoAttack", false);
			//Debug.Log("Level 2");
		}
		if (6 <= distance && distance < 8)
		{
			modelAnimation.SetBool("RhinoAttack", false);
			//Debug.Log("Level 3");
		}
		if (4.5 <= distance && distance < 6)
		{
            canvasImage.SetActive(true);
			modelAnimation.SetBool("RhinoAttack", true);
            AchievementManager.Instance.UnlockAchievement("Riot");
            //Debug.Log("Level 4");
        }
		if (3.0 <= distance && distance < 4.5)
		{
			canvasImage.SetActive(true);
			modelAnimation.SetBool("RhinoAttack", true);
            AchievementManager.Instance.UnlockAchievement("Riot");
            //Debug.Log("Level 5");
        }
		if (2.0 < distance && distance < 3.0)
		{
			canvasImage.SetActive(true);
			modelAnimation.SetBool("RhinoAttack", true);
            AchievementManager.Instance.UnlockAchievement("Riot");
            //Debug.Log("Level 6");
        }
		if (2.0 > distance)
		{
			canvasImage.SetActive(true);
			modelAnimation.SetBool("RhinoAttack", true);
            AchievementManager.Instance.UnlockAchievement("Riot");
            //Debug.Log("Level 7");
        }
	}
}