using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg : MonoBehaviour
{
    private Renderer render;
    private Vector2 spd;
    void Start()
    {
        render = GetComponent<Renderer>();
        spd = new Vector2(Mathf.Lerp(g.iBgspd.x, g.fBgspd.x, (g.maxScore+1)/(g.GetScore()+1)), 0f);
    }

    // Update is called once per frame
    void Update() {
        if(!PauseHandler.estaPausado && !SceneTransitions.transitioning) {
            spd = new Vector2(Mathf.Lerp(g.iBgspd.x, g.fBgspd.x, ((float)g.GetScore()+1f)/(float)g.maxScore), 0f);
            render.material.mainTextureOffset += spd * Time.deltaTime * Time.deltaTime / transform.localScale.x;
        }
    }



}
