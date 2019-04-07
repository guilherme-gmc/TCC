﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 hspd;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        hspd = new Vector2(-300f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = hspd * Time.deltaTime;
    }
}
