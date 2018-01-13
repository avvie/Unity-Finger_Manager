using UnityEngine;

public class Finger {
	public int id;
	public TouchPhase phase;
	public Vector2 screenPosition, lastScreenPosition;
	public Vector3 worldPosition, lastWorldPosition, Wdirection;
	public Vector2 Sdirection;
	public Finger(int d) {
		id = d;
	}

	public Finger(int d, TouchPhase p, Vector2 Spos, Vector3 Wpos) {
		id = d;
		phase = p;
		screenPosition = Spos;
		worldPosition = Wpos;
		//2d Only
		worldPosition.z = 0;
	}

	public void MoveFinger(Touch t) {
		phase = t.phase;
		lastScreenPosition = screenPosition;
		screenPosition = t.position;
		lastWorldPosition = worldPosition;
		worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
		
		//2d Only
		worldPosition.z = 0;

		if (t.phase == TouchPhase.Moved) {
			Sdirection = screenPosition - lastScreenPosition;
			Wdirection = worldPosition - lastWorldPosition;
		}
		else {
			Sdirection = Vector2.zero;
			Wdirection = Vector3.zero;
		}

	}
}
