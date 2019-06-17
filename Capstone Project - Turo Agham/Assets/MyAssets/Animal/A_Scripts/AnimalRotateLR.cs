/*
* Copyright (c) Creative Code Studio
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimalRotateLR : MonoBehaviour {

	#region Variables
	public float rotateSpeed = 500f;
	#endregion

	#region Methods
	void OnMouseDrag()
	{
		if (!IsPointerOverUIObject())
		{
			float rotX = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;

			this.transform.Rotate(Vector3.up, -rotX, Space.World);
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
