using UnityEngine;
using System.Collections;

public class KeyIconFade : MonoBehaviour {
	SpriteRenderer sprite;
	TextMesh text;
	SpriteRenderer icon;
	float speed = 2f;

	Color targetColor = new Color(1f,1f,1f,0f);
	// Use this for initialization
	void Awake () {
		sprite = GetComponent<SpriteRenderer> ();
		text = GetComponentInChildren<TextMesh> ();
		if (transform.FindChild ("icon"))
			icon = transform.FindChild ("icon").GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		sprite.color = Color.Lerp (sprite.color, targetColor, Time.deltaTime * speed);
		text.color = Color.Lerp (sprite.color, targetColor, Time.deltaTime * speed);

		if(icon)
			icon.color = Color.Lerp (icon.color, targetColor, Time.deltaTime * speed);
	}

	void OnTriggerEnter(Collider other){
		//make sure our last forced shift was a bit ago so we don't accidentally do it twice
		if (other.gameObject.tag == "Player") {
			targetColor = new Color (1f, 1f, 1f, 1f);
		}
	}

	void OnTriggerExit(Collider other){
		//make sure our last forced shift was a bit ago so we don't accidentally do it twice
		if (other.gameObject.tag == "Player") {
			targetColor = new Color (1f, 1f, 1f, 0f);
		}
	}

}
