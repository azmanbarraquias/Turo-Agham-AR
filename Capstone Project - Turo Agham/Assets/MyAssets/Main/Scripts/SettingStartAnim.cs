/*
* Copyright (c) Creative Code Studio
*/

using System.Collections;
using UnityEngine;

public class SettingStartAnim : MonoBehaviour {

	#region Variables
	public Animator settingAnim;
	#endregion

	#region Methods
	// Use this for initialization

	void OnEnable () 
	{
		settingAnim.SetTrigger("OpenSetting");
	}
	
	public void CloseSetting () 
	{
		StartCoroutine(CloseSettingDelay());
	}

	IEnumerator CloseSettingDelay()
	{
		settingAnim.SetTrigger("CloseSetting");
				yield return new WaitForSecondsRealtime(10f);
		settingAnim.gameObject.SetActive(false);
	}
	#endregion
}
