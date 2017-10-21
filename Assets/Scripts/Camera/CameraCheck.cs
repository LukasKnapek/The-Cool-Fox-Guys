using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCheck : MonoBehaviour {

    private Camera mainCamera;
 
	// Use this for initialization
	void Start () {
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(this.GetComponent<SpriteRenderer>().isVisible);
	}

    public void OnBecameInvisible()
    {
        //mainCamera.GetComponent<CameraBehavior>().IncreaseCameraSize();
    }
}
