using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	[SerializeField]
	AudioClip beatClip;
	[SerializeField]
	AudioClip melodyClip;

	AudioSource bgmMelody;
	AudioSource bgmBeat;
	// Use this for initialization
	void Start () {
		bgmMelody = Utils.AddAudio (gameObject, melodyClip, true, true, 0.6f);
		bgmBeat = Utils.AddAudio (gameObject, beatClip, true, false, 0.4f);
		bgmMelody.Play ();
	}
	
	void OnLevelWasLoaded(int level) {
		if (level == 2 && !bgmBeat.isPlaying) {
			bgmBeat.Play ();
			bgmBeat.time = bgmMelody.time;
			bgmMelody.Stop ();
		}

	}
}
