using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    private GameObject player;
    private Transform playerTransform;
    private float yOffset = 2.5f;

    // Use this for initialization

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
    }

    public void Update()
    {
        if (player != null)
        {
            Vector3 cameraPos = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffset, transform.position.z);
            transform.position = cameraPos;
        }
    }
}
