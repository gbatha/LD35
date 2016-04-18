using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
	[SerializeField]
	string level;

	bool loading = false;

	void Update() {
		if (Input.anyKeyDown && !loading) {
			loading = true;
			SceneManager.LoadScene (level);
		}

	}

}
