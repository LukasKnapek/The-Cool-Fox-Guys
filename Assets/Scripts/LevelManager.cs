using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        GameMaster.hardMode = false;
        SceneManager.LoadScene(name);
    }

    public void LoadLevelHardMode(string name)
    {
        GameMaster.hardMode = true;
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game requested");
        Application.Quit();
    }
}
