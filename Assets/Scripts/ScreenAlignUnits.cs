using UnityEngine;
using System.Collections;

public class ScreenAlignUnits : MonoBehaviour {
	[SerializeField]
	bool top = false;
	[SerializeField]
	bool bottom = false;
	[SerializeField]
	bool left = false;
	[SerializeField]
	bool right = false;

	[SerializeField]
	float unitsX;
	[SerializeField]
	float unitsY;
	[SerializeField]
	bool alignAtStart = true;
	// Use this for initialization
	void Start () {
		if(alignAtStart)
			refreshAlignment();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void refreshAlignment(){
		Vector3 pos = transform.position;

		if (unitsY >= 0f) {
			if(top){
				pos.y = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y - unitsY;
			}else if(bottom){
				pos.y = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y + unitsY;
			}
		}

		if (unitsX >= 0f) {
			if(right){
				pos.x = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x - unitsX;
			}else if(left){
				pos.x = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x + unitsX;
			}
		}

		transform.position = pos;
	}
}
