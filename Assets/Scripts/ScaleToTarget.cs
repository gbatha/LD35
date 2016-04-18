using UnityEngine;
using System.Collections;

public class ScaleToTarget : MonoBehaviour {
	public Vector3 target = Vector3.one;
	float speed = 4f;
	float sensitivity = 0.02f;
	float delay = 0f;

	// Use this for initialization
	void Start () {
		target = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale != target) {
			//if we're within the sensitivity just round it to the target
			if (Vector3.Distance (transform.localScale, target) <= sensitivity) {
				transform.localScale = target;
			} else {
				//otherwise let's lerp it up!
				transform.localScale = Vector3.Lerp(transform.localScale, target, Time.deltaTime * speed);
			}
		}
	}

	void setTargetScale(Vector3 targetIn){
		target = targetIn;
//		StartCoroutine ( delaySetTargetScale(targetIn, 0.1f) );
	}
		
	IEnumerator delaySetTargetScale(Vector3 targetIn, float delay){
		yield return new WaitForSeconds (delay);
		target = targetIn;
	}
}
