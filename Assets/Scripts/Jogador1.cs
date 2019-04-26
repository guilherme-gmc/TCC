﻿using UnityEngine.SceneManagement;
using UnityEngine;

public class Jogador1 : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool roofed;
    private Vector2 grav;
    private Vector2 vspd;
    private Vector2 jmpSpd;
    private Vector2 jmpAccel;
    private Vector2 hspd;
    private Vector2 spd;
    private bool mousePressed;

    private SceneTransitions sceneTrans;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sceneTrans = GameObject.Find("Canvas").GetComponent<SceneTransitions>();
        grav = new Vector2(0f, -12f);
        jmpAccel = new Vector2(0f, 22f);
        jmpSpd = new Vector2(0f, 220f);
        vspd = new Vector2(0f, 0f);
        hspd = new Vector2(180f, 0f);
        spd = new Vector2();
        spd = hspd + vspd;
        grounded = false;
        roofed = false;
        mousePressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!SceneTransitions.transitioning && !PauseHandler.estaPausado)
        {
            anim.speed = 1;
            mousePressed = Input.GetMouseButton(0) ? true : false;
            //Apply gravity
            if (!grounded)
            {
                if (PauseHandler.estaPausado)
                    return;
                vspd += grav;
            }

            if (!roofed && mousePressed)
            {
                vspd += jmpAccel;
            }

            if (grounded && Input.GetMouseButtonDown(0))
            {
                vspd += jmpSpd;
            }

            body.velocity = (hspd + vspd) * Time.deltaTime;
        } else
        {
            anim.speed = 0;
            body.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            vspd.y = 0;
        }
        else if (collision.gameObject.tag == "Roof")
        {
            roofed = true;
            vspd.y = 0f;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if(!mousePressed)
            {
                grounded = true;
                vspd.y = 0;
            }
        } else if (collision.gameObject.tag == "Roof") {
            if(mousePressed)
            {
                roofed = true;
                vspd.y = 0f;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }

        if (collision.gameObject.tag == "Roof")
        {
            roofed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy1")
        {
            sceneTrans.ChangeScene("gameOver");
        } else if(collision.gameObject.tag == "Consumable")
        {
            g.ScoreInc();
            Destroy(collision.gameObject);
        }
    }

}
