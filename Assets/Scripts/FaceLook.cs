using UnityEngine;
using System.Collections;

public class FaceLook : MonoBehaviour {
	public float radius = 0.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 offsetTarget = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0f);
		offsetTarget *= radius;

		Vector3 pos = transform.localPosition;
		pos = Vector3.Lerp (transform.localPosition, offsetTarget, Time.deltaTime * 100f);
		transform.localPosition = pos;
	}
}
