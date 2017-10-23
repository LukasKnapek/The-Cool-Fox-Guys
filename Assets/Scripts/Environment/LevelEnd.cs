using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

    private bool playerWolfReached;
    private bool playerFoxReached;
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerFox") playerFoxReached = true;
        if (other.gameObject.name == "PlayerWolf") playerWolfReached = true;

        if (playerFoxReached && playerWolfReached)
        {
            GameMaster.GM.Win();
        }
    }
}
