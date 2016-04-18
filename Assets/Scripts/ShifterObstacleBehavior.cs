using UnityEngine;
using System.Collections;

public class ShifterObstacleBehavior : MonoBehaviour {
	[SerializeField]
	int shiftBy = -1;

	float lastShift = 0f;
	float forceShiftSensitivity = 3f; //time in seconds until we can force a shift again


	void OnTriggerEnter(Collider col){
		//make sure our last forced shift was a bit ago so we don't accidentally do it twice
		if (col.gameObject.tag == "Player" && Time.time - lastShift > forceShiftSensitivity) {
			col.gameObject.SendMessage ("SwitchShapeBy", shiftBy);
			lastShift = Time.time;
		}
	}
}
