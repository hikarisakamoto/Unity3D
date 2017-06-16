using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate() //LateUpdate runs after all itens have been processed by update
    {
        transform.position = player.transform.position + offset;
    }
}
