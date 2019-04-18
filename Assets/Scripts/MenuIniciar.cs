using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuIniciar : MonoBehaviour {

    private SceneTransitions sceneTransitions;
	// Use this for initialization
	void Start () {
        sceneTransitions = GameObject.Find("Canvas").GetComponent<SceneTransitions>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	public void CarregarMsg(){
		SceneManager.LoadScene ("Mensagens");
	}
	public void CarregarJogo(){
        sceneTransitions.ChangeScene("gameStart");
	}

	public void SairJogo(){
		Application.Quit ();
	}

	public void CarregarConfiguracoes(){
		SceneManager.LoadScene ("MenuConf");
	}

}
