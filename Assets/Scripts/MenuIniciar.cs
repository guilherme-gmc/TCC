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
        StartCoroutine(GameObject.Find("Canvas").GetComponent<SceneTransitions>().ChangeScene("gameStart"));
	}

	public void SairJogo(){
		Application.Quit ();
	}

	public void CarregarMenuInicial(){
		SceneManager.LoadScene ("MenuInicial");
	}

	public void CarregarConfiguracoes(){
		SceneManager.LoadScene ("MenuConf");
	}

}
