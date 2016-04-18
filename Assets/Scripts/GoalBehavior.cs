using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoalBehavior : MonoBehaviour {
	[SerializeField]
	string nextLevel;

	[SerializeField]
	ParticleSystem[] fireWorks;

	bool triggered = false;

	void OnTriggerEnter(Collider other){
		//make sure our last forced shift was a bit ago so we don't accidentally do it twice
		if (other.gameObject.tag == "Player" && !triggered) {
			for (int i = 0; i < fireWorks.Length; i++) {
				Utils.PlayParticleSystem (fireWorks [i], true);
				StartCoroutine (delayLoadNextScene (3f));
			}
		}
	}

	IEnumerator delayLoadNextScene(float delay){
		if (nextLevel != "") {
			yield return new WaitForSeconds (delay);
			SceneManager.LoadScene (nextLevel);
		}
	}
}
