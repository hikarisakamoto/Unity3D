﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float padding = 1;

	private float xMax, xMin;

	void Start ()
	{

		float distance = (transform.position.z) - (Camera.main.transform.position.z);
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xMin = leftmost.x + padding;
		xMax = rightmost.x - padding;
	}

	void Update ()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
//			transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);

			transform.position += Vector3.left * speed * Time.deltaTime;

		} else if (Input.GetKey (KeyCode.RightArrow)) {
//			transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);

			transform.position += Vector3.right * speed * Time.deltaTime;

		}
//		Restric the player to the Game space
		float newX = Mathf.Clamp (transform.position.x, xMin, xMax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

	}
}
