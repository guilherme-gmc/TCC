using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
	
	private static Music instance = null;
	private AudioSource musicSource;
	private static bool muted = false;

	void Start() {
		musicSource = GetComponent<AudioSource>();
	}

	private void Awake(){
		if (instance != null){
			Destroy(gameObject);
		}else{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	public void ToggleSound(){
		musicSource = GetComponent<AudioSource>();
		if(!IsMuted) {
			musicSource.mute = true;
			IsMuted = true;
		} else {
			musicSource.mute = false;
			IsMuted = false;
		}
	}

	public static bool IsMuted {
		get {return muted;}
		set {muted = value;}
	}



}
