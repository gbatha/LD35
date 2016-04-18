using UnityEngine;
using System.Collections;

public class GrateBehavior : MonoBehaviour {
	[SerializeField]
	BoxCollider mainCollider;

	bool ignoredLiquid = false; //we ALWAYS want to ignore liquid, so if we haven't already make sure we do

//	void OnTriggerEnter(Collider other) {
//		if (other.gameObject.tag == "Player") {
//			Debug.Log ("stay");
//			HandleCollision (other);
//		}
//	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			HandleCollision (other);
		}
	}

//	void OnTriggerExit(Collider other) {
//		if (other.gameObject.tag == "Player") {
//			Debug.Log ("trigger left");
//			Physics.IgnoreCollision (other.GetComponent<Collider>(), mainCollider, false);
//		}
//	}

	void HandleCollision(Collider other){
		if (other.gameObject.tag == "Player") {
			ShapeMode shape = other.gameObject.GetComponent<ShapeShifterController> ().shape;
			//if the player is solid, we don't ignore the collision
			if (shape == ShapeMode.Solid) {
				Physics.IgnoreCollision (other.gameObject.GetComponent<ShapeShifterController> ().solidCollider, mainCollider, false);
			} else {
				//otherwise, we ignore the collision
				Physics.IgnoreCollision (other.gameObject.GetComponent<ShapeShifterController> ().solidCollider, mainCollider);
				if (!ignoredLiquid) {
					Physics.IgnoreCollision (other.gameObject.GetComponent<ShapeShifterController> ().liquidCollider, mainCollider);
					ignoredLiquid = true;
				}
			}
		}
	}
}
