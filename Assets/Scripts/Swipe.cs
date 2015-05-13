using UnityEngine;
using System.Collections;

public class Swipe : MonoBehaviour {
	public Vector2 startPos;
	public Vector2 direction;
	public bool directionChosen;
	public GameObject obj;
	private float distance;
	void Update() {
		// Track a single touch as a direction control.
		if (Input.touchCount > 0) {
			var touch = Input.GetTouch(0);
			
			// Handle finger movements based on touch phase.
			switch (touch.phase) {
				// Record initial touch position.
			case TouchPhase.Began:
				startPos = touch.position;
				directionChosen = false;
				break;
				
				// Determine direction by comparing the current touch position with the initial one.
			case TouchPhase.Moved:
				direction = touch.position - startPos;
				distance = touch.position.x - startPos.x;
				obj.transform.Rotate(0, 0, distance * Time.deltaTime);
				break;
				
				// Report that a direction has been chosen when the finger is lifted.
			case TouchPhase.Ended:
				directionChosen = true;
				break;
			}
		}
		if (directionChosen) {

		//	obj.transform.Rotate(0, 0, distance *Time.deltaTime);
		}
	}
}