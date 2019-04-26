using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choco : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 hspd;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        hspd = g.hspd;
    }

    // Update is called once per frame
    void Update()
    {
        if(!SceneTransitions.transitioning && !PauseHandler.estaPausado)
        {
        body.velocity = hspd * Time.deltaTime;
        } else
        {
            body.velocity = Vector2.zero;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    
}
