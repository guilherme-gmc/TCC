using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (PauseHandler.estaPausado)
			return;

        transform.position = new Vector3(player.transform.position.x + 6, 0f, -10f);
	}

}
