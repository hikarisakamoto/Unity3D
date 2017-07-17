using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball
    : MonoBehaviour
{
    //public Vector3 launchVelocity;

    private AudioSource audioSource;
    private Rigidbody rigidBody;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        rigidBody.useGravity = false;

        //  Launch(launchVelocity);
    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(transform.position);
    }

    public void Launch(Vector3 velocity)
    {
        rigidBody.velocity = velocity;
        rigidBody.useGravity = true;
        audioSource.Play();

    }

}

