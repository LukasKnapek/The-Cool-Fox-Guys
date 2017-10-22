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
    public static AudioSource mainPlayer;
    private Slider powerBarFox;
    private Slider powerBarWolf;

    private GameObject playerWolf;
    private GameObject playerFox;

    public static bool reached1;
    public static bool reached2;
    public static bool reached3;
    public static bool reached4;
   
    public static GameObject checkPoint1;
    public static GameObject checkPoint2;
    public static GameObject checkPoint3;
    public static GameObject checkPoint4;


    void Awake()
    {

        playerWolf = GameObject.Find("PlayerWolf");
        playerFox = GameObject.Find("PlayerFox");

        checkPoint1 = GameObject.Find("CheckPoint1");
        checkPoint2 = GameObject.Find("CheckPoint2");
        checkPoint3 = GameObject.Find("CheckPoint3");
        checkPoint4 = GameObject.Find("CheckPoint4");

        if (reached4)
        {
            playerWolf.transform.position = checkPoint4.transform.position;
            playerFox.transform.position = checkPoint4.transform.position;
        }
        else if (reached3)
        {
            playerWolf.transform.position = checkPoint3.transform.position;
            playerFox.transform.position = checkPoint3.transform.position;
        }
        else if (reached2)
        {
            playerWolf.transform.position = checkPoint2.transform.position;
            playerFox.transform.position = checkPoint2.transform.position;
        }
        else if (reached1)
        {
            playerWolf.transform.position = checkPoint1.transform.position;
            playerFox.transform.position = checkPoint1.transform.position;
        }


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
            reached1 = checkPoint1.GetComponent<CheckpointScript>().isReached();
            reached2 = checkPoint2.GetComponent<CheckpointScript>().isReached();
            reached3 = checkPoint3.GetComponent<CheckpointScript>().isReached();
            reached4 = checkPoint4.GetComponent<CheckpointScript>().isReached();

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
        reached1 = checkPoint1.GetComponent<CheckpointScript>().isReached();
        reached2 = checkPoint2.GetComponent<CheckpointScript>().isReached();
        reached3 = checkPoint3.GetComponent<CheckpointScript>().isReached();
        reached4 = checkPoint4.GetComponent<CheckpointScript>().isReached();

        gameOverScreen = GameObject.Find("UI").GetComponent<Transform>().Find("GameOverScreen").GetComponent<Image>();
        gameOverText = GameObject.Find("UI").GetComponent<Transform>().Find("GameOverText").GetComponent<Text>();
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();

        gameOverScreen.enabled = true;
        gameOverScreen.canvasRenderer.SetAlpha(0.0f);
        gameOverScreen.CrossFadeAlpha(1.0f, 1.5f, true);

        gameOverText.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 1f);
        gameOverText.canvasRenderer.SetAlpha(0.0f);
        gameOverText.CrossFadeAlpha(1.0f, 1.5f, true);

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
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("GameOver");
    }

    IEnumerator Victory()
    {
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene("Win");
    }
}
