using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarMapa : MonoBehaviour {

	public GameObject Teto2;
	public GameObject Chao2;
	public GameObject Teto;
	public GameObject Chao;

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > Chao.transform.position.x) {
			var tempTeto = Teto2;
			var tempChao = Chao2;
			Teto2 = Teto;
			Chao2 = Chao;
			tempTeto.transform.position += new Vector3 (80, 0, 0);
			tempChao.transform.position += new Vector3 (80, 0, 0);
			Teto = tempTeto;
			Chao = tempChao;
		}

	}
}
