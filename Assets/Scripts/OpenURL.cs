using UnityEngine;
using System.Collections;

public class OpenURL : MonoBehaviour {
	[SerializeField]
	string url;

	void OnMouseOver ()
	{
		if (Input.GetMouseButtonDown (0) == true)
		{
			Debug.Log ("clicked");
			Application.OpenURL (url);
		}
	}
}
