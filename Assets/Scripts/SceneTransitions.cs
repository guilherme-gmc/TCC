using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    private GameObject gameEyes;
    private GameObject gameBd;
    private Animator eyesAnim;
    private Animator bdAnim;
    private float tranDuration;
    private float fadeDuration;

    public static bool transitioning;
    public static string _context;

    // Start is called before the first frame update
    void Start()
    {
        gameEyes = transform.Find("gameEyes").gameObject;
        gameBd = transform.Find("gameBackdrop").gameObject;
        eyesAnim = gameEyes.GetComponent<Animator>();
        bdAnim = gameBd.GetComponent<Animator>();

        tranDuration = 2.95f;
        fadeDuration = 0.95f;
        if(transitioning)
        {
            StartCoroutine(TransitionFade());
        }
    }

    public void ChangeScene(string context)
    {
        StartCoroutine(ChangeSceneCoroutine(context));
    }

    private IEnumerator ChangeSceneCoroutine(string context)
    {
        _context = context;
        gameEyes.SetActive(true);
        gameBd.SetActive(true);
        if(context == "gameOver")
        {
            eyesAnim.SetTrigger("gameOver");
            bdAnim.SetTrigger("gameOver");
            transitioning = true;
            yield return new WaitForSeconds(tranDuration);
            SceneManager.LoadScene("MenuInicial");
        } else if(context == "gameStart")
        {
            eyesAnim.SetTrigger("gameStart");
            bdAnim.SetTrigger("gameStart");
            transitioning = true;
            yield return new WaitForSeconds(tranDuration);
            SceneManager.LoadScene("Jogo1");

        } else if(context == "gameNext") {
            bdAnim.SetTrigger("gameStart");
            transitioning = true;
            yield return new WaitForSeconds(fadeDuration);
            SceneManager.LoadScene("Jogo2");
        }
    }

    private IEnumerator TransitionFade()
    {
        gameEyes.SetActive(true);
        gameBd.SetActive(true);
        if(_context == "gameStart")
        {
            bdAnim.SetTrigger("gameStartOut");
            yield return new WaitForSeconds(fadeDuration);
            gameEyes.SetActive(false);
            gameBd.SetActive(false);
            transitioning = false;
        } else if (_context == "gameOver")
        {
            bdAnim.SetTrigger("gameOverOut");
            yield return new WaitForSeconds(fadeDuration);
            gameEyes.SetActive(false);
            gameBd.SetActive(false);
            transitioning = false;
        } else if (_context == "gameNext")
        {
            bdAnim.SetTrigger("gameStartOut");
            yield return new WaitForSeconds(fadeDuration);
            gameBd.SetActive(false);
            transitioning = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
