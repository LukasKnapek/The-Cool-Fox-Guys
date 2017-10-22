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
    public Text restartText;
    public Camera mainCamera;
    public AudioSource mainPlayer;
    private Slider powerBarFox;
    private Slider powerBarWolf;

    void Awake()
    {
        if (GM == null)
            GM = this;
        else if (GM != null)
            Destroy(gameObject);

        mainPlayer = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        ControlBindings = new Dictionary<string, List<string>>
        {
            { "Button1", new List<string>() {"Door1"} },
            { "Button2", new List<string>() {"Door2"} },
            { "Button3", new List<string>() {"Door3"} },
            { "Lever1", new List<string>() {"Bridge1"}},
            { "Lever2", new List<string>() {"Bridge2"}},
            { "Lever3", new List<string>() {"Bridge3"}},
            { "Lever", new List<string>() {"Bridge"}},
            { "Button", new List<string>() {"Barrier"}}
        };

        powerBarFox = GameObject.Find("UI").GetComponent<Transform>().Find("PowerBarFox").GetComponent<Slider>();
        powerBarWolf = GameObject.Find("UI").GetComponent<Transform>().Find("PowerBarWolf").GetComponent<Slider>();
        restartText = GameObject.Find("UI").GetComponent<Transform>().Find("RestartText").GetComponent<Text>();

    }

    private void Update()
    {
        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene("Level 1");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Menu");
        }

        if (restartText != null)
        {
            if (powerBarFox.value <= 0 || powerBarWolf.value <= 0)
            {
                restartText.enabled = true;
            }
            else
            {
                restartText.enabled = false;
            }
        }
        else
        {
            powerBarFox = GameObject.Find("UI").GetComponent<Transform>().Find("PowerBarFox").GetComponent<Slider>();
            powerBarWolf = GameObject.Find("UI").GetComponent<Transform>().Find("PowerBarWolf").GetComponent<Slider>();
            restartText = GameObject.Find("UI").GetComponent<Transform>().Find("RestartText").GetComponent<Text>();
            restartText.enabled = false;

        }

    }

    public void GameOver()
    {
        mainPlayer.Stop();
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
        mainPlayer.Stop();
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

        SceneManager.LoadScene("GameOver");

    }

    IEnumerator Victory()
    {
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene("Win");

    }
}
