using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
	
	private static Music instance = null;
	private static bool muted = false;

	private void Awake(){
		if (instance != null){
			Destroy(gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	public static bool IsMuted {
		get {return muted;}
		set {muted = value;}
	}



}
