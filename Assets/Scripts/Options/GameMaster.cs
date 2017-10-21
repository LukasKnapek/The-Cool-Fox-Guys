using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster GM;

    public Dictionary<string, List<string>> ControlBindings;
    public Image gameOverScreen;
    public Text gameOverText;
    public Camera mainCamera;

    void Awake()
    {
        if (GM == null)
            GM = this;
        else if (GM != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        ControlBindings = new Dictionary<string, List<string>>
        {
            {"Button1", new List<string>() {"Door1"} }
        };

    }

    public void GameOver()
    {
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

        StartCoroutine(Waiter());

    }

    IEnumerator Waiter()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
