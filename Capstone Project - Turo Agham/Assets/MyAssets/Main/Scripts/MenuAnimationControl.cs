/*
* Copyright (c) Creative Code Studio
*/

using UnityEngine;

public class MenuAnimationControl : MonoBehaviour {

	#region Variables
	public Animator[] MenuSlideAnim;
	#endregion

	#region Methods
	public void Menu_1_Out()
	{
		MenuSlideAnim[0].SetInteger("MenuSlideAnim", 1);
	}
	public void Menu_1_In()
	{
		MenuSlideAnim[0].SetInteger("MenuSlideAnim", -1);
	}

	public void Menu_2_Out()
	{
		MenuSlideAnim[1].SetInteger("MenuSlideAnim", 1);
	}
	public void Menu_2_In()
	{
		MenuSlideAnim[1].SetInteger("MenuSlideAnim", -1);
	}

	public void Menu_3_Out()
	{
		MenuSlideAnim[2].SetInteger("MenuSlideAnim", 1);
	}
	public void Menu_3_In()
	{
		MenuSlideAnim[2].SetInteger("MenuSlideAnim", -1);
	}

	public void Menu_4_Out()
	{
		MenuSlideAnim[3].SetInteger("MenuSlideAnim", 1);
	}
	public void Menu_4_In()
	{
		MenuSlideAnim[3].SetInteger("MenuSlideAnim", -1);
	}
	#endregion
}
