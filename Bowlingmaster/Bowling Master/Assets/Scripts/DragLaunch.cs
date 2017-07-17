using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    private Ball ball;
    private Vector3 inputPosition;
    private float dragTime;
    private bool ballWaiting = true;

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

    public void MoveSideways(float movementAmount)
    {
        if (ballWaiting)
        {
            Vector3 currentPosition = new Vector3(Mathf.Clamp(ball.transform.position.x, -39, 39), ball.transform.position.y, ball.transform.position.z);

            ball.transform.position = currentPosition + (new Vector3(movementAmount, 0, 0));
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
        if (ballWaiting)
        {
            // Launch the ball
            inputPosition = Input.mousePosition - inputPosition;
            dragTime = Time.time - dragTime;

            Vector3 velocity = new Vector3(0f, 0f, (inputPosition.y / dragTime));

            ball.Launch(velocity);
            ballWaiting = false;
        }
    }
}
