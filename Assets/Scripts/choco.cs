using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choco : MonoBehaviour
{
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!SceneTransitions.transitioning && !PauseHandler.estaPausado)
        {
        body.velocity = g.hspd * Time.deltaTime;
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
