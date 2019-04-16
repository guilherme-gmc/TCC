using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour {

	public GameObject menu;
	static public bool estaPausado;

	// Use this for initialization
	void Start () {

		menu = Instantiate (menu, menu.transform.position, menu.transform.rotation) as GameObject;
		Pause (false);

	}

	void Pause(bool statusPause){
		estaPausado = statusPause;
		menu.SetActive (estaPausado);

		if (estaPausado) {

			Time.timeScale = 0;

		} else {
			Time.timeScale = 1;
		}

	}
	
	// Update is called once per frame
	public void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause (!estaPausado);
		}
	}
}
