using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    private GameObject gameEyes;
    private GameObject gameBd;
    private Animator eyesAnim;
    private Animator bdAnim;
    private GameObject tutorial1;
    private GameObject tutorial2;
    private float tranDuration;
    private float fadeDuration;

    public static bool transitioning;
    public static bool playTutorial1 = true;
    public static bool playTutorial2 = true;
    public static bool playCutscene1 = true;
    public static string _context;
    private Music music;

    void Start()
    {
        gameEyes = transform.Find("gameEyes").gameObject;
        gameBd = transform.Find("gameBackdrop").gameObject;
        eyesAnim = gameEyes.GetComponent<Animator>();
        bdAnim = gameBd.GetComponent<Animator>();
        music = GameObject.Find("Music").GetComponent<Music>();

        if((playTutorial1 || playCutscene1) && SceneManager.GetActiveScene().name == "Jogo1") {
            tutorial1 = transform.Find("Tutorial1").gameObject;
        } else if(playTutorial2 && SceneManager.GetActiveScene().name == "Jogo2") {
            tutorial2 = transform.Find("Tutorial2").gameObject;
        }

        tranDuration = 2.95f;
        fadeDuration = 0.95f;
        if(transitioning) {
            StartCoroutine(TransitionFade());
        }
    }

    public void ChangeScene(string context)
    {
        g.ResetScore();
        StartCoroutine(ChangeSceneCoroutine(context));
    }

    private IEnumerator ChangeSceneCoroutine(string context, bool resetHp = false)
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
        } else if(context == "gameCont") {
            bdAnim.SetTrigger("gameStart");
            transitioning = true;
            yield return new WaitForSeconds(fadeDuration);
            g.hp = g.maxHp;
            SceneManager.LoadScene("Jogo1");
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
            if(playTutorial1) {
                playTutorial1 = false;
                tutorial1.SetActive(true);
                tutorial1.GetComponent<Animator>().SetTrigger("tutorial");
                yield return new WaitForSeconds(22f);
                transitioning = false;
                yield return new WaitForSeconds(3.5f);
                tutorial1.SetActive(false);
            }
            transitioning = false;
        } else if (_context == "gameOver")
        {
            bdAnim.SetTrigger("gameOverOut");
            music.SetMusic("menu");
            yield return new WaitForSeconds(fadeDuration);
            gameEyes.SetActive(false);
            gameBd.SetActive(false);
            transitioning = false;
        } else if (_context == "gameNext")
        {
            bdAnim.SetTrigger("gameStartOut");
            music.SetMusic("boss");
            yield return new WaitForSeconds(fadeDuration);
            gameBd.SetActive(false);
            transitioning = false;
            if(playTutorial2) {
                playTutorial2 = false;
                tutorial2.SetActive(true);
                yield return new WaitForSeconds(4f);
                tutorial2.SetActive(false);
            }
        } else if (_context == "gameCont")
        {
            bdAnim.SetTrigger("gameStartOut");
            music.SetMusic("menu");
            yield return new WaitForSeconds(fadeDuration);
            gameBd.SetActive(false);
            if(playCutscene1) {
                playCutscene1 = false;
                tutorial1.SetActive(true);
                tutorial1.GetComponent<Animator>().SetTrigger("cutscene");
                yield return new WaitForSeconds(18.5f);
                transitioning = false;
                tutorial1.SetActive(false);
            }
            transitioning = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
