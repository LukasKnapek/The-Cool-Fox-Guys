using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game requested");
        Application.Quit();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
