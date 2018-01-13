using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class FingerManager {
	List<Finger> fingers = new List<Finger>();
	public int Count = 0;


	Finger linearSearchId(int id) {
		foreach(Finger finger in fingers) {
			if (finger.id == id)
				return finger;
		}
		return new Finger(-1);
	}

	public void delete(int id) {
		fingers.Remove(linearSearchId(id));
	}

	public void addFinger(Touch touch) {
		if(touch.phase == TouchPhase.Began) {
			fingers.Add(new Finger(touch.fingerId, 
				touch.phase, 
				touch.position, 
				Camera.main.ScreenToWorldPoint(touch.position)));
		}
		Count++;
	}

	public bool touchExists(Touch touch, bool addToList) {
		if (addToList) {
			if (touch.phase == TouchPhase.Began) {
				addFinger(touch);
				return false;
			}

			Finger temp = linearSearchId(touch.fingerId);
			if (temp.id == -1) {
				addFinger(touch);
				return true;
			}
			return false;
		}
		else {
			Finger temp = linearSearchId(touch.fingerId);
			if (temp.id == -1) {
				return true;
			}
			return false;
		}
	}

	public List<Finger> ClearFingers() {
		fingers.Clear();
		Count = 0;
		return fingers;
	}

	public List<Finger> updateList(Touch[] touches) {
		Finger temp;
		foreach (Touch t in touches) {
			//Debug.Log(t.phase);
			if (t.phase == TouchPhase.Canceled || t.phase == TouchPhase.Ended)
				delete(t.fingerId);

			if (t.phase == TouchPhase.Began)
				touchExists(t, true);

			if(t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary) {
				temp = linearSearchId(t.fingerId);
				temp.MoveFinger(t);
			}

		}
		return fingers;
	}

}
