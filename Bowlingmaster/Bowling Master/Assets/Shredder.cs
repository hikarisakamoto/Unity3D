using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        GameObject thingLeaving = other.gameObject;

        if (thingLeaving.GetComponent<Pin>())
        {
            Destroy(thingLeaving);
        }
    }
}
