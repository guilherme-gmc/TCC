using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMute : MonoBehaviour {
	private AudioSource musicSource;
	void Start() {
		musicSource = GameObject.Find("Music").GetComponent<AudioSource>();
	}

	public void ToggleSound(){
		musicSource = GameObject.Find("Music").GetComponent<AudioSource>();
		if(!Music.IsMuted) {
			musicSource.mute = true;
			Music.IsMuted = true;
		} else {
			musicSource.mute = false;
			Music.IsMuted = false;
		}
	}

	public void ToggleSound(bool mute){
		musicSource = GameObject.Find("Music").GetComponent<AudioSource>();
		musicSource.mute = mute;
		Music.IsMuted = mute;
	}

}
