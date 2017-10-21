using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    private Transform playerTransform;
    private float yOffset = 2.5f;

    // Use this for initialization

    public void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void Update()
    {
        Vector3 cameraPos = new Vector3(playerTransform.position.x, playerTransform.position.y+yOffset, transform.position.z);
        transform.position = cameraPos;

    }
}
