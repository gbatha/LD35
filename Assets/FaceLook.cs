using UnityEngine;
using System.Collections;

public class FaceLook : MonoBehaviour {
	public float radius = 0.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		Vector3 pos = transform.localPosition;
		pos.x = offset.x * radius;
		pos.y = offset.y * radius;
		transform.localPosition = pos;
	}
}
