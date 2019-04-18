using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private PauseHandler pauseHandler;
    private SceneTransitions sceneTransitions;

    private void Start()
    {
        pauseHandler = GameObject.Find("PauseHandler").GetComponent<PauseHandler>();
        sceneTransitions = GameObject.Find("Canvas").GetComponent<SceneTransitions>();
    }
    public void ResumeGame()
    {
        pauseHandler.Pause(false);
    }

    public void CarregarMenuInicial()
    {
        sceneTransitions.ChangeScene("gameOver");
        pauseHandler.Pause(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
