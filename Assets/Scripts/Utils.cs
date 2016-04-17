using UnityEngine;
using System.Collections;

public class Utils {

	public static float map (float value, float istart, float istop, float ostart, float ostop) {
		return ostart + (ostop - ostart) * ((value - istart) / (istop - istart));
	}

	public static AudioSource AddAudio(GameObject gameObject, AudioClip clip, bool loop, bool playAwake, float vol) {
		AudioSource newAudio = gameObject.AddComponent<AudioSource>();
		newAudio.clip = clip;
		newAudio.loop = loop;
		newAudio.playOnAwake = playAwake;
		newAudio.volume = vol;
		return newAudio;
	}

	public static void shuffle(int[,] ints){
		for (int i = 0; i < ints.GetLength(0); i++) {
			// Knuth shuffle algorithm :: courtesy of Wikipedia :)
			for (int t = 0; t < ints.GetLength(1); t++ ){
				
				int tmp = ints[i,t];
				
				int r = Random.Range(t, ints.GetLength(1));
				
				ints[i,t] = ints[i,r];
				
				ints[i,r] = tmp;
				
			}		
		}
	}

	public static void shuffle(int[] ints){
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < ints.Length; t++ ){
			
			int tmp = ints[t];
			
			int r = Random.Range(t, ints.Length);
			
			ints[t] = ints[r];
			
			ints[r] = tmp;
			
		}		
	}

	//formats a displaytime to the time that's passed in. displays -:-- if -1 is passed in
	public static void displayFormattedTime(float timeIn, TextMesh timemesh, TextMesh timemeshcenti, bool multByScale = false){
		if(timeIn == -1f){
			timemesh.text = "-:--";
			timemeshcenti.text = "";
		}else{
			int minutes = (int)(timeIn / 60f);
			int seconds = (int)(timeIn % 60);
			int centisecond = (int)((timeIn - Mathf.Floor(timeIn)) * 100f);

			timemesh.text = string.Format("{0}:{1:D2}", minutes, seconds);
			timemeshcenti.text = string.Format("{0:D2}", centisecond);
		}
		
		//position centitext
		Vector3 centiPos = timemeshcenti.transform.localPosition;
		if(multByScale){
			centiPos.x = timemesh.GetComponent<Renderer>().bounds.size.x * (1f/timemesh.transform.lossyScale.x);
			//centiPos.x += 0.1f;
		}else{
			centiPos.x = timemesh.GetComponent<Renderer>().bounds.size.x + 0.1f;	
		}
		
		timemeshcenti.transform.localPosition = centiPos;
	}

	public static bool collidesWithSlider(Vector2 inputIn, GameObject gameObjIn){
		int layerMask = 1 << gameObjIn.layer;
		Collider2D col = Physics2D.OverlapPoint(inputIn, layerMask);
		if(col == gameObjIn.GetComponent<Collider2D>()){
			return true;
		}else{
			return false;
		}
	}

	public static void PlayParticleSystem(ParticleSystem tp, bool letPlay){
		if(letPlay)
		{
//			if(!tp.isPlaying)
//			{
				tp.Play();
//			}
		}else{
//			if(tp.isPlaying)
//			{
				tp.Stop();
//			}
		}
	}
}
