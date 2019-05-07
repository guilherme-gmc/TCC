using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(!SceneTransitions.transitioning && !PauseHandler.estaPausado)
        {
        body.velocity = new Vector2(Mathf.Lerp(g.iHspd.x, g.fHspd.x, ((float)g.GetScore()+1f)/(float)g.maxScore), 0f) * Time.deltaTime;
        } else {
            body.velocity = Vector2.zero;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    
}
