using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

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

    public IEnumerator ChangeScene(string context)
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

        } else
        {
            print("Please input a valid context for the ChangeScene Coroutine");
        }
    }

    public IEnumerator TransitionFade()
    {
        gameEyes.SetActive(true);
        gameBd.SetActive(true);
        if(_context == "gameStart")
        {
            eyesAnim.SetTrigger("gameStartOut");
            bdAnim.SetTrigger("gameStartOut");
            yield return new WaitForSeconds(fadeDuration);
            gameEyes.SetActive(false);
            gameBd.SetActive(false);
            transitioning = false;
        } else if (_context == "gameOver")
        {
            eyesAnim.SetTrigger("gameOverOut");
            bdAnim.SetTrigger("gameOverOut");
            yield return new WaitForSeconds(fadeDuration);
            gameEyes.SetActive(false);
            gameBd.SetActive(false);
            transitioning = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
