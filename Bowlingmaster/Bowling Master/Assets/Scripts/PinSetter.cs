using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class PinSetter : MonoBehaviour
{
    public Text standingDisplay;
    public int lastStandingCount = -1;
    public GameObject pinSet;


    private bool ballEnteredBox = false;
    private float lastChangeTime;
    private Ball ball;

    private void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    private void Update()
    {
        standingDisplay.text = CountStanding().ToString();

        if (ballEnteredBox)
        {
            UpdateStandingCountAndSettle();
        }
    }

    void UpdateStandingCountAndSettle()
    {
        // Update the lastStandingCount
        // Call PinsHaveSattle() when they have

        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; // How long to wait to consider pins settled

        if ((Time.time - lastChangeTime) > settleTime) // If last change > settleTime
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        ball.Reset();
        lastStandingCount = -1; // Indicates pins have settled, and ball not in box
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
    }

    int CountStanding()
    {
        int standing = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject thingHit = collider.gameObject;

        //Ball enters playbox
        if (thingHit.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }



    public void RaisePins()
    {
        // Raise standing pins only by distanceToRaise
        Debug.Log("Raising Pins");

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }

    }

    public void LowerPins()
    {
        Debug.Log("Lowering Pins");

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        //Renew pins
        Debug.Log("Renewing Pins");
        Instantiate(pinSet, new Vector3(0, 5, 1829), Quaternion.identity);

    }
}
