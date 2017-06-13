using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()// Best for follow cameras, procidural animations and get last known states -> It will run after all itens have been 
                             // processed in Update
    {
        transform.position = player.transform.position + offset;
    }
}
