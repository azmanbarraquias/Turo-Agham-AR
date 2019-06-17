/*
* Copyright (c) Creative Code Studio
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetOnClick : MonoBehaviour
{
	#region Variables
	public Camera cam;
	public float raycastRange = 500f;
	public Transform planetToActive;
	public Transform planetInfomation;
	#endregion

	#region Methods
	void Update()
	{
		if (!IsPointerOverUIObject())
		{
			if (Input.GetMouseButtonDown(0))
			{
				RaycastHit hit;
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray, out hit, raycastRange)) //send info back value to RaycastHit hit;
				{
					Debug.Log(hit.transform.name);
					foreach (Transform planet in planetToActive)
					{
						if (hit.transform.name == planet.gameObject.name)
						{
							planet.gameObject.SetActive(true);
						}
						else
						{
							planet.gameObject.SetActive(false);
						}
					}
				}
			}
		}
	}

	public void TurnOffMiniPlanetInfo()
	{
		foreach (Transform planet in planetToActive)
		{
			planet.gameObject.SetActive(false);
		}
	}

	private bool IsPointerOverUIObject()
	{
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}
	#endregion
}