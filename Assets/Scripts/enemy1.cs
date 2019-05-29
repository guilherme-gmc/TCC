using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 spd;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(!SceneTransitions.transitioning && !PauseHandler.estaPausado) {
            if(SceneTransitions._context == "gameCont" && Boss.lost) {
                spd = new Vector2(Mathf.Lerp(g.iHspd.x, g.fHspd2.x, ((float)g.GetScore()+1f)/(float)g.maxScore), 0f);
            } else {
                spd = new Vector2(Mathf.Lerp(g.iHspd.x, g.fHspd.x, ((float)g.GetScore()+1f)/(float)g.maxScore), 0f);
            }
            body.velocity = spd * Time.deltaTime;
        } else {
            body.velocity = Vector2.zero;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    
}
