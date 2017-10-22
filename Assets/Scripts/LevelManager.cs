using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        GameMaster.hardMode = false;
        DestroyObjects.helpText = false;
        SceneManager.LoadScene(name);
    }

    public void LoadLevelHardMode(string name)
    {
        GameMaster.hardMode = true;
        DestroyObjects.helpText = false;
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game requested");
        Application.Quit();
    }
}
