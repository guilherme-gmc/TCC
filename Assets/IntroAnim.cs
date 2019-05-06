using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnim : MonoBehaviour
{
    private static bool openingApp = true;
    private GameObject introAnim;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        introAnim = transform.Find("IntroAnim").gameObject;
        anim = introAnim.GetComponent<Animator>();
        if(openingApp) {
            anim.SetTrigger("introAnim");
            openingApp = false;
        } else {
            anim.SetTrigger("introIdle");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
