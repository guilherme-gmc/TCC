using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuIniciar : MonoBehaviour {

    private SceneTransitions sceneTransitions;
	private GameObject credits;
	private Animator anim;

	void Start () {
        sceneTransitions = GameObject.Find("Canvas").GetComponent<SceneTransitions>();
		anim = GameObject.Find("Canvas").transform.Find("IntroAnim").GetComponent<Animator>();
		credits = transform.Find("IntroAnim").Find("CreditosText").gameObject;
    }
	
	public void CarregarJogo(){
        sceneTransitions.ChangeScene("gameStart");
	}

	public void SairJogo(){
		Application.Quit ();
	}

	public void CarregarCreditos() {
		anim.SetTrigger("creditsStart");
	}

	public void VoltarCreditos() {
		anim.SetTrigger("creditsEnd");
	}

}
