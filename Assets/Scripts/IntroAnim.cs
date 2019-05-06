using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnima : MonoBehaviour
{
    private static bool openingApp = true;
    private GameObject introAnim;
    private GameObject eventSystem;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        introAnim = transform.Find("IntroAnim").gameObject;
        eventSystem = GameObject.Find("EventSystem").gameObject;
        anim = introAnim.GetComponent<Animator>();
        if(openingApp) {
            StartCoroutine(EventSystemCoroutine());
            anim.SetTrigger("introAnim");
            openingApp = false;
        } else {
            anim.SetTrigger("introIdle");
        }
    }

    public static bool IsAppOpening() {
        return openingApp;
    }

    private IEnumerator EventSystemCoroutine() {
        eventSystem.SetActive(false);
        yield return new WaitForSeconds(6.0f);
        eventSystem.SetActive(true);
    }
}
