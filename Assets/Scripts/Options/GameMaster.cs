using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster GM;

    public Dictionary<string, List<string>> ControlBindings;
    public static Image gameOverScreen;
    public static Image winScreen;
    public static Text gameOverText;
    public static Text restartText;
    public static Camera mainCamera;
    public static AudioSource mainPlayer;
    private static Slider powerBarFox, powerBarWolf;

    private GameObject playerWolf, playerFox;

    public static bool reached1;
    public static bool reached2;
    public static bool reached3;
    public static bool reached4;
   
    public static GameObject checkPoint1;
    public static GameObject checkPoint2;
    public static GameObject checkPoint3;
    public static GameObject checkPoint4;

    public static bool hardMode;

    enum State {Alive, GameOver, Victory};
    State playerState;

    void Awake()
    {
        playerFox = FindObjectOfType<PlayerFoxMove>().gameObject;
        playerWolf = FindObjectOfType<PlayerWolfMove>().gameObject;

        checkPoint1 = GameObject.Find("CheckPoint1");
        checkPoint2 = GameObject.Find("CheckPoint2");
        checkPoint3 = GameObject.Find("CheckPoint3");
        checkPoint4 = GameObject.Find("CheckPoint4");

        powerBarFox = FindObjectOfType<PowerBarFox>().GetComponent<Slider>();
        powerBarWolf = FindObjectOfType<PowerBarWolf>().GetComponent<Slider>();
        restartText = GameObject.Find("RestartText").GetComponent<Text>();

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

        if (hardMode)
        {
            checkPoint1.transform.position = new Vector2(-200, -200);
            checkPoint2.transform.position = new Vector2(-200, -200);
            checkPoint3.transform.position = new Vector2(-200, -200);
            checkPoint4.transform.position = new Vector2(-200, -200);
        }

        playerState = State.Alive;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Restart") && restartText.enabled)
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
            //restartText.enabled = false;
        }
    }

    public void GameOver()
    {
        if (playerState != State.GameOver)
        {
            playerState = State.GameOver;
            reached1 = checkPoint1.GetComponent<CheckpointScript>().isReached();
            reached2 = checkPoint2.GetComponent<CheckpointScript>().isReached();
            reached3 = checkPoint3.GetComponent<CheckpointScript>().isReached();
            reached4 = checkPoint4.GetComponent<CheckpointScript>().isReached();

            gameOverScreen = GameObject.Find("GameOverScreen").GetComponent<Image>();
            gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
            mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();

            gameOverScreen.enabled = true;
            gameOverScreen.canvasRenderer.SetAlpha(0.0f);
            gameOverScreen.CrossFadeAlpha(1.0f, 1.5f, true);

            gameOverText.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 1f);
            gameOverText.canvasRenderer.SetAlpha(0.0f);
            gameOverText.CrossFadeAlpha(1.0f, 1.5f, true);

            StartCoroutine(Defeat());
        }
    }

    public void Win()
    {
        if (playerState != State.Victory)
        {
            playerState = State.Victory;
            mainPlayer.Stop();
            winScreen = GameObject.Find("WinScreen").GetComponent<Image>();
            mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();

            winScreen.enabled = true;
            winScreen.canvasRenderer.SetAlpha(0.0f);
            winScreen.CrossFadeAlpha(1.0f, 2.0f, true);

            StartCoroutine(Victory());
        }
        
    }

    IEnumerator Defeat()
    {
        yield return new WaitForSeconds(2f);
        playerState = State.Alive;

        SceneManager.LoadScene("GameOver");
    }

    IEnumerator Victory()
    {
        yield return new WaitForSeconds(2.5f);
        playerState = State.Alive;

        SceneManager.LoadScene("Win");
    }
}
