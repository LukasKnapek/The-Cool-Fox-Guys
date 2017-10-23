using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static bool debugMode;

    public void LoadLevel(string name)
    {
        GameReset();
        GameMaster.hardMode = false;
        DestroyObjects.helpText = debugMode = false;
        SceneManager.LoadScene(name);
    }

    public void LoadLevelHardMode(string name)
    {
        GameReset();
        GameMaster.hardMode = true;
        DestroyObjects.helpText = debugMode = false;
        SceneManager.LoadScene(name);
    }

    public void LoadLevelDebugMode(string name)
    {
        debugMode = true;
        DestroyObjects.helpText = GameMaster.hardMode = false;
        SceneManager.LoadScene(name);
    }

    void GameReset()
    {
        GameMaster.reached1 = false;
        GameMaster.reached2 = false;
        GameMaster.reached3 = false;
        GameMaster.reached4 = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quit game requested");
        Application.Quit();
    }
}
