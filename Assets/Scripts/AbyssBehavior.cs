using UnityEngine;
using System.Collections;

public class AbyssBehavior : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		//make sure our last forced shift was a bit ago so we don't accidentally do it twice
		if (col.gameObject.tag == "Player") {
			col.gameObject.SendMessage ("Respawn");
		}
	}
}
