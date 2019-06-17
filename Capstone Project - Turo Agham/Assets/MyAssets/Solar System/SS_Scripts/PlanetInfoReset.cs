/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;
using TMPro;

public class PlanetInfoReset : MonoBehaviour {
	
	#region Variables
	bool isPlanetMenuActive = false;
	public AudioSource audioSource;
	public TextMeshProUGUI resetName;
	public TextMeshProUGUI resetDisciption;
	public GameObject PlanetMenu;
	public GameObject QuickBtn;
	public GameObject MiniPlanetBtn;
	public Animator planetSelectionMenu;
	#endregion

	#region Methods

	public void SetMenuTrue()
	{
		isPlanetMenuActive = true;
	}

	public void SetMenuFalse()
	{
		isPlanetMenuActive = false;
	}

	public void OpenQuickMenuBtn()
	{
		planetSelectionMenu.SetBool("OpenQuickMenu", true);
	}
	public void CloseQuickMenuBtn()
	{
		planetSelectionMenu.SetBool("OpenQuickMenu", false);
	}

	public void ExitPlanetInfo()
	{
		audioSource.Stop();
		audioSource.clip = null;
		resetName.text = "";
		resetDisciption.text = "";

		if (isPlanetMenuActive == true)
		{
			planetSelectionMenu.SetBool("OpenQuickMenu", true);
		}
		else
		{
			planetSelectionMenu.SetBool("OpenQuickMenu", false);
			QuickBtn.SetActive(true);
		}
	}

	public void ExitPlanetInfoAR()
	{
		audioSource.Stop();
		audioSource.clip = null;
		resetName.text = "";
		resetDisciption.text = "";
	}

	public void HideMiniPlanetBtn()
	{
		MiniPlanetBtn.SetActive(false);
	}
	#endregion
}