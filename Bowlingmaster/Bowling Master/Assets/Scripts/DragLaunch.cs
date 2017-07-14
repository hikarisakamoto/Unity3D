using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    private Ball ball;
    private Vector3 inputPosition;
    private float dragTime;

    private void Start()
    {
        ball = GetComponent<Ball>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DragStart();
            if (Input.GetMouseButtonUp(1))
            {
                DragEnd();
            }
        }
    }

    public void DragStart()
    {
        // Capture time & position of drag start - Stores time & position
        inputPosition = Input.mousePosition;
        dragTime = Time.time;
    }

    public void DragEnd()
    {
        // Launch the ball
        inputPosition = Input.mousePosition - inputPosition;
        dragTime = Time.time - dragTime;

        Vector3 velocity = new Vector3(inputPosition.x, 0f, (inputPosition.y / dragTime));

        ball.Launch(velocity);
    }
}
