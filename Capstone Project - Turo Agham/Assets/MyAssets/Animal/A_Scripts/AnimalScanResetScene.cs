/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalScanResetScene : MonoBehaviour {
	
	#region Variables
	public static bool animalScanStartMenuActive = true;
	public GameObject[] toActive;
	#endregion
	
	#region Methods
	// Use this for initialization
	void Awake () 
	{
		if (animalScanStartMenuActive == false)
		{
			foreach (var item in toActive)
			{
				item.SetActive(false);
			}
		}
	}

	// Update is called once per frame

	public void BackToHome () 
	{
		animalScanStartMenuActive = true;
	}

	public void ResetScene()
	{
		animalScanStartMenuActive = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	#endregion
}