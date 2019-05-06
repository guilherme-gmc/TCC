using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMute : MonoBehaviour {
	private AudioSource musicSource;
	void Start() {
		musicSource = GameObject.Find("Music").GetComponent<AudioSource>();
	}

	public void ToggleSound(){
		if(!Music.IsMuted) {
			musicSource.mute = true;
			Music.IsMuted = true;
		} else {
			musicSource.mute = false;
			Music.IsMuted = false;
		}
	}	

}
