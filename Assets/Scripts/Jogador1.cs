using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador1 : MonoBehaviour
{
    Rigidbody2D body;
    bool grounded;
    bool roofed;
    Vector2 grav;
    Vector2 vSpd;
    Vector2 jmpSpd;
    Vector2 jmpAccel;
    Vector2 hSpd;
    Vector2 spd;
    bool mouseDown;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        grav = new Vector2(0f, -12f);
        jmpAccel = new Vector2(0f, 22f);
        jmpSpd = new Vector2(0f, 220f);
        vSpd = new Vector2(0f, 0f);
        hSpd = new Vector2(180f, 0f);
        spd = new Vector2();
        spd = hSpd + vSpd;
        grounded = false;
        roofed = false;
        mouseDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseDown = Input.GetMouseButton(0) ? true : false;
        //Apply gravity
        if (!grounded)
        {
            vSpd += grav;
        }

        if (!roofed && mouseDown)
        {
            vSpd += jmpAccel;
        }

        body.velocity = (hSpd + vSpd) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            vSpd.y = 0;
        }
        else if (collision.gameObject.tag == "Roof")
        {
            roofed = true;
            vSpd.y = 0f;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if(!mouseDown)
            {
                grounded = true;
                vSpd.y = 0;
            }
        } else if (collision.gameObject.tag == "Roof") {
            if(mouseDown)
            {
                roofed = true;
                vSpd.y = 0f;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
            vSpd += jmpSpd;
        }

        if (collision.gameObject.tag == "Roof")
        {
            roofed = false;
        }
    }

}
