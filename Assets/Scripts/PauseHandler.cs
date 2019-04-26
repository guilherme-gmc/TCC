using System.Collections;
using UnityEngine;

public class PauseHandler : MonoBehaviour {

    private GameObject pausePrefab;
	private GameObject menu;
	static public bool estaPausado;

	// Use this for initialization
	void Start () {

        pausePrefab = Resources.Load<GameObject>("Prefabs/MenuPausado");
        menu = Instantiate (pausePrefab) as GameObject;
		Pause (false);

	}

	public void Pause(bool statusPause){
		estaPausado = statusPause;
		menu.SetActive(estaPausado);
	}
	
	// Update is called once per frame
	public void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause (!estaPausado);
		}

	}

}
