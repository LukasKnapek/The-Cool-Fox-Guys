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
    public Image winScreen;
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
            { "Button1", new List<string>() {"Door1"} },
            { "Button2", new List<string>() {"Door2"} },
            { "Button3", new List<string>() {"Door3"} },
            { "Lever1", new List<string>() {"Bridge1"}},
            { "Lever2", new List<string>() {"Bridge2"}},
            { "Lever3", new List<string>() {"Bridge3"}}
        };

    }

    public void GameOver()
    {
        gameOverScreen = GameObject.Find("UI").GetComponent<Transform>().Find("GameOverScreen").GetComponent<Image>();
        gameOverText = GameObject.Find("UI").GetComponent<Transform>().Find("GameOverText").GetComponent<Text>();
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();

        gameOverScreen.enabled = true;
        gameOverScreen.canvasRenderer.SetAlpha(0.0f);
        gameOverScreen.CrossFadeAlpha(1.0f, 2.0f, true);

        gameOverText.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 1f);
        gameOverText.canvasRenderer.SetAlpha(0.0f);
        gameOverText.CrossFadeAlpha(1.0f, 2.0f, true);

        StartCoroutine(Defeat());

    }

    public void Win()
    {
        winScreen = GameObject.Find("UI").GetComponent<Transform>().Find("WinScreen").GetComponent<Image>();
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();

        winScreen.enabled = true;
        winScreen.canvasRenderer.SetAlpha(0.0f);
        winScreen.CrossFadeAlpha(1.0f, 2.0f, true);

        StartCoroutine(Victory());
    }

    IEnumerator Defeat()
    {
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    IEnumerator Victory()
    {
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
