using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnim : MonoBehaviour
{
    private static bool openingApp = true;
    private GameObject introAnim;
    private GameObject eventSystem;
    private Animator anim;
    private MenuMensagens msg;
    private AudioMute audio;
    void Start()
    {
        introAnim = transform.Find("IntroAnim").gameObject;
        eventSystem = GameObject.Find("EventSystem").gameObject;
        anim = introAnim.GetComponent<Animator>();
        msg = GameObject.Find("Message").GetComponent<MenuMensagens>();
        audio = GameObject.Find("Canvas").GetComponent<AudioMute>();

        if(openingApp) {
            anim.SetTrigger("introAnim");
            openingApp = false;
            audio.ToggleSound(false);
        } else {
            anim.SetTrigger("introIdle");
            msg.SwitchMessage();
        }
    }

    public static bool IsAppOpening() {
        return openingApp;
    }
}
