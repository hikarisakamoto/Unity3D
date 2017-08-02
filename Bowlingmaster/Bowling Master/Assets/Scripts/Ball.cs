using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball
    : MonoBehaviour
{
    //public Vector3 launchVelocity;
    public bool inPlay = false;

    private AudioSource audioSource;
    private Rigidbody rigidBody;
    private Vector3 ballInitialPosition;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        ballInitialPosition = transform.position;
        rigidBody.useGravity = false;

        //  Launch(launchVelocity);
    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(transform.position);
    //}

    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        rigidBody.velocity = velocity;
        rigidBody.useGravity = true;
        audioSource.Play();

    }

    public void Reset()
    {
        //Debug.Log("Resetting ball!");
        inPlay = false;
        rigidBody.useGravity = false;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        transform.position = ballInitialPosition;
    }

}

