using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    private Image gameOverScreen;
    private Text gameOverText;
    public Camera mainCamera;


    // Use this for initialization
    void Start () {
        gameOverScreen = GameObject.Find("UI").GetComponent<Transform>().Find("GameOverScreen").GetComponent<Image>();
        gameOverText = GameObject.Find("UI").GetComponent<Transform>().Find("GameOverText").GetComponent<Text>();
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();

        gameOverScreen.enabled = true;
        gameOverScreen.canvasRenderer.SetAlpha(0.0f);
        gameOverScreen.CrossFadeAlpha(1.0f, 3.0f, true);

        gameOverText.enabled = true;
        gameOverText.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 1f);
        gameOverText.canvasRenderer.SetAlpha(0.0f);
        gameOverText.CrossFadeAlpha(1.0f, 3.0f, true);
    }
	
	// Update is called once per frame
	void Update () {

    }
}
