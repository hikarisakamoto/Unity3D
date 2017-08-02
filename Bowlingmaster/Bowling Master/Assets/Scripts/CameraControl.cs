﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Ball ball;

    private Vector3 offset;


    private void Start()
    {
        offset = transform.position - ball.transform.position;
    }

    private void Update()
    {
        if (ball.transform.position.z <= 1820f) //In Front of head pin 
        {
            transform.position = ball.transform.position + offset;
        }
    }
}
