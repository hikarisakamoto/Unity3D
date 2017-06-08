﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
	public bool autoPlay = false;

	private Ball ball;


	void Start ()
	{
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	// Update is called once per frame
	void Update ()
	{ 
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
	}

	void MoveWithMouse ()
	{
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);		
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;		
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, 0.7f, 15.3f);
		
		this.transform.position = paddlePos;
	}

	void AutoPlay ()
	{
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);		
		Vector3 ballPosition = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPosition.x, 0.7f, 15.3f);
		
		this.transform.position = paddlePos;
	}
}
