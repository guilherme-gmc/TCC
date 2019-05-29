using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg : MonoBehaviour
{
    private Renderer render;
    private Vector2 spd;
    public Material bg1;
    public Material bg2;

    void Start() {
        render = GetComponent<Renderer>();
        if(SceneTransitions._context == "gameCont" && Boss.lost) {
            GetComponent<MeshRenderer>().material = bg2;
            spd = new Vector2(Mathf.Lerp(g.iBgspd.x, g.fBgspd2.x, (g.maxScore+1)/(g.GetScore()+1)), 0f);
        } else {
            GetComponent<MeshRenderer>().material = bg1;
            spd = new Vector2(Mathf.Lerp(g.iBgspd.x, g.fBgspd.x, (g.maxScore+1)/(g.GetScore()+1)), 0f);
        }

    }

    // Update is called once per frame
    void Update() {
        if(!PauseHandler.estaPausado && !SceneTransitions.transitioning) {
            if(SceneTransitions._context == "gameCont" && Boss.lost) {
                spd = new Vector2(Mathf.Lerp(g.iBgspd.x, g.fBgspd2.x, ((float)g.GetScore()+1f)/(float)g.maxScore), 0f);
            } else {
                spd = new Vector2(Mathf.Lerp(g.iBgspd.x, g.fBgspd.x, ((float)g.GetScore()+1f)/(float)g.maxScore), 0f);
            }
            render.material.mainTextureOffset += spd * Time.deltaTime * Time.deltaTime / transform.localScale.x;
        }
    }



}
