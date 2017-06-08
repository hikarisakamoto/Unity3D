﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	private Paddle paddle;

	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start ()
	{
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted) {
			// Locks the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}
		// Waiting for mouse press to launch
		if (Input.GetMouseButtonDown (0)) {
			hasStarted = true;
			print ("Mouse clicked, launch ball");
			this.rigidbody2D.velocity = new Vector2 (2f, 10f);
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		Vector2 ballBounce = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		if (hasStarted) {
			audio.Play ();
			rigidbody2D.velocity += ballBounce;
		}
	}
}