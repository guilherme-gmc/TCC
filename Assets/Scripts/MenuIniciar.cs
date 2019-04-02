using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuIniciar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void CarregarMsg(){
		SceneManager.LoadScene ("Mensagens");
	}
	public void CarregarJogo(){
		SceneManager.LoadScene ("Jogo1");
	}
}
