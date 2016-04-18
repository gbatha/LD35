using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
	[SerializeField]
	string level;

	bool loading = false;

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space) && !loading) {
			loading = true;
			SceneManager.LoadScene (level);
		}

	}

}
