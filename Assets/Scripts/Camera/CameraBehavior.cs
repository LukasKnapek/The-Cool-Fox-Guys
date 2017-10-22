using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    private SpriteRenderer wolfLeft;
    private SpriteRenderer wolfRight;
    private SpriteRenderer wolfUp;
    private SpriteRenderer wolfDown;

    private SpriteRenderer wolfLeftRenderer;
    private SpriteRenderer wolfRightRenderer;
    private SpriteRenderer wolfUpRenderer;
    private SpriteRenderer wolfDownRenderer;

    private GameObject playerFox;
    private GameObject playerWolf;

    private Transform playerTransform;
    private Camera mainCamera;
    private float yOffset = 0f;
    private bool canDecreaseSize;

    // Use this for initialization

    public void Start()
    {
        mainCamera = this.GetComponent<Camera>();

        wolfLeftRenderer = GameObject.Find("PlayerWolfLeftCameraCheck").GetComponent<SpriteRenderer>();
        wolfRightRenderer = GameObject.Find("PlayerWolfRightCameraCheck").GetComponent<SpriteRenderer>();
        wolfUpRenderer = GameObject.Find("PlayerWolfUpCameraCheck").GetComponent<SpriteRenderer>();
        wolfDownRenderer = GameObject.Find("PlayerWolfDownCameraCheck").GetComponent<SpriteRenderer>();

        wolfLeft = GameObject.Find("PlayerWolfLeftCheck").GetComponent<SpriteRenderer>();
        wolfRight = GameObject.Find("PlayerWolfRightCheck").GetComponent<SpriteRenderer>();
        wolfUp = GameObject.Find("PlayerWolfUpCheck").GetComponent<SpriteRenderer>();
        wolfDown = GameObject.Find("PlayerWolfDownCheck").GetComponent<SpriteRenderer>();

        playerFox = GameObject.Find("PlayerFox");
        playerWolf = GameObject.Find("PlayerWolf");

        playerTransform = playerFox.GetComponent<Transform>();
        canDecreaseSize = true;
    }

    public void Update()
    {
        if (playerFox != null)
        {
            Vector3 cameraPos = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
            transform.position = cameraPos;      
        }

        if (playerWolf != null)
        {
            if (!wolfLeft.isVisible || !wolfRight.isVisible || !wolfUp.isVisible || !wolfDown.isVisible)
            {
                mainCamera.orthographicSize += 0.05f;
            }
            else
            {
                if (wolfLeftRenderer.isVisible && wolfRightRenderer.isVisible && wolfUpRenderer.isVisible && wolfDownRenderer.isVisible && mainCamera.orthographicSize > 6)
                {
                    mainCamera.orthographicSize -= 0.05f;
                }
            }
        }
        
    }

}
