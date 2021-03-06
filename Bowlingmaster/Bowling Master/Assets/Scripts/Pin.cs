﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float standingThreshold = 3f;
    public float distanceToRaise = 40f;

    //private float distanceToLower;
    private Rigidbody rigidBody;

    void Awake()
    {
        this.GetComponent<Rigidbody>().solverVelocityIterations = 23;
    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        //distanceToLower = distanceToLower - 1f;
    }

    private void Update()
    {
        //print(name + IsStanding());
    }

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if (tiltInX < standingThreshold && tiltInZ < standingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RaiseIfStanding()
    {
        // Raise standing pins only by distanceToRaise
        //Debug.Log("Raising Pin");

        if (IsStanding())
        {
            rigidBody.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
        }
    }

    public void Lower()
    {
        //Debug.Log("Lowering Pin");
        //rigidBody.useGravity = true;
        transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
        rigidBody.useGravity = true;

    }

}
