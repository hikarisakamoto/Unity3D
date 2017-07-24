﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    public Text standingDisplay;

    private bool ballEnteredBox = false;

    private void Update()
    {
        standingDisplay.text = CountStanding().ToString();
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

    private void OnTriggerExit(Collider other)
    {
        GameObject thingLeaving = other.gameObject;

        if (thingLeaving.GetComponent<Pin>())
        {
            Destroy(thingLeaving);
        }
    }
}
