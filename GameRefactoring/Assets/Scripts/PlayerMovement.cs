﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 800f;

    Rigidbody2D rbody;
    float horiz;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        horiz = Input.GetAxis("Horizontal");


#if UNITY_ANDROID
        horiz = Input.acceleration.x;
#endif
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player_ChargeMissle"))
            rbody.velocity = Vector2.zero;
        else
            rbody.velocity = new Vector2(horiz * speed * Time.deltaTime, 0);
    }
}