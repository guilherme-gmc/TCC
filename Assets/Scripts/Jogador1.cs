using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador1 : MonoBehaviour {
	Rigidbody body;
	// Use this for initialization
	void Start () {
		
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (MenuPause.estaPausado)
			return;

		if (Input.GetMouseButton (0)) {
			body.AddForce (new Vector3 (0, 50, 0), ForceMode.Acceleration);
		} else if (Input.GetMouseButtonUp (0)) {
			body.velocity *= 0.25f;
		}
	}
}
