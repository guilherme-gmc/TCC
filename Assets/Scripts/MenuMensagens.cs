using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMensagens : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void CarregarInicio(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("MenuInicial");
	}
}
