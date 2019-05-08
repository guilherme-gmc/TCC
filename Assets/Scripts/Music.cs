using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
	
	private static Music instance = null;
	private static bool muted = false;
	private AudioSource source;
	public AudioClip bossMusic;
	public AudioClip menuMusic;

	private void Awake(){
		if (instance != null){
			Destroy(gameObject);
		} else {
			instance = this;
			source = GetComponent<AudioSource>();
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	public static bool IsMuted {
		get {return muted;}
		set {muted = value;}
	}

	public void SetMusic(string theme = "menu") {
		if(theme == "boss") {
			source.clip = bossMusic;
			source.Play();
		} else if(theme == "menu") {
			source.clip = menuMusic;
			source.Play();
		}
	}

}
