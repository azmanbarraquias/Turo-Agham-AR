/*
* Copyright (c) Creative Code Studio
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// this visible only on orthographic camera view mode
public class PanAndZoomControl : MonoBehaviour {

	#region Variables
	Vector3 touchStart;
	
	[Header("Adjustment")]
	public float zoomOutMin = 1f;
	public float zoomInMax = 8f;
	public float zoomSpeed = 0.01f;
	#endregion

	#region Methods

	// Update is called once per frame
	void Update ()
	{
		Camera.main.transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.position.x, -350, 110), //left , right
										 Mathf.Clamp(Camera.main.transform.position.y, -3, 140), // up down
										 Camera.main.transform.position.z);
		if (!IsPointerOverUIObject())
		{
			// get the first touch position, this only true for the start of the touch
			if (Input.GetMouseButtonDown(0)) // can be change to (Input.touchCount == 1)
			{
				// We use ScreenToWorldPoint to convert touch position to world cordinate
				touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				//Debug.Log(touchStart);
			}

			// check if there is 2 input touch directed on the screen
			// Zoom - Mobile
			if (Input.touchCount == 2)
			{
				// store both touch info
				Touch touchFirst = Input.GetTouch(0);
				Touch touchSecond = Input.GetTouch(1);

				// compare touch position, current and previous or last touch position,
				// .delta posiiton - The position delta since last change.
				Vector2 touchZeroPreviousPosition = touchFirst.position - touchFirst.deltaPosition;
				Vector2 touchOnePreviousPosition = touchSecond.position - touchSecond.deltaPosition;

				// store magnitude of our previous position, magnitude - calculate length the distance between position
				float preMagnitude = (touchZeroPreviousPosition - touchOnePreviousPosition).magnitude;
				// calculate position our current position
				float currentMagnitude = (touchFirst.position - touchSecond.position).magnitude;

				// find difference
				float difference = currentMagnitude - preMagnitude;

				Zoom(difference * zoomSpeed);
			}

			// this return true for the entirely the touch is down
			else if (Input.GetMouseButton(0))
			{
				// get the direction of the first touch is heading to...
				Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
				// Now we can move the position of the camera
				Camera.main.transform.position += direction;
				//Debug.Log(direction);
			}
			// Zoom - PC
			Zoom((Input.GetAxis("Mouse ScrollWheel")) * zoomSpeed);
		}                                   // PAN //
	}

	// this adjust the orthographicSize
	void Zoom(float increment)
	{   // Access the camera orthographicSize
		// Mathf.Clamp - Clamps a value between a minimum float and maximum float value.
		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment,zoomInMax, zoomOutMin);
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