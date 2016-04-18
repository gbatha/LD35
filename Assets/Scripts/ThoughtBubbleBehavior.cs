using UnityEngine;
using System.Collections;

public class ThoughtBubbleBehavior : MonoBehaviour {
	[SerializeField]
	Transform bubbleTarget;
	[SerializeField]
	Transform anchor;

	[SerializeField]
	Transform[] trailBubbles;

	[SerializeField]
	float followIntensity = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Vector3.Lerp (transform.position, bubbleTarget.position, Time.deltaTime * followIntensity);
		pos.z = -1f;
		transform.position = pos;
		for (int i = 0; i < trailBubbles.Length; i++) {
			float amount = ((float)i + 1f) / ((float)trailBubbles.Length + 2f);
			trailBubbles [i].position = Vector3.Lerp (anchor.position, transform.position, amount);
		}
	}
}
