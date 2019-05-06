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
		anim = transform.Find("IntroAnim").GetComponent<Animator>();
		credits = transform.Find("IntroAnim").Find("CreditosText").gameObject;
    }
	
	public void CarregarJogo(){
        sceneTransitions.ChangeScene("gameStart");
	}

	public void SairJogo(){
		if(credits.activeSelf) {
			anim.SetTrigger("creditsEnd");
		} else {
			Application.Quit ();
		}
	}

	public void CarregarCreditos() {
		anim.SetTrigger("creditsStart");
	}

}
