using UnityEngine;
using System.Collections;

public class ScreenShotImage : MonoBehaviour {
	[SerializeField]
	int superSize = 1;
	[SerializeField]
	string key = "s";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(key)){
			string now = System.DateTime.Now.ToString("MM-dd-yyyy H.mm.ss");
			string filename = "ScreenshotFolder/"+now+".png";
			Application.CaptureScreenshot(filename, superSize);
			Debug.Log("screenshot saved as "+filename);
		}
	}
}
