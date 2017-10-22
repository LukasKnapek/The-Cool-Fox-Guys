using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour {

    public bool reached;
    private bool playerWolfReached;
    private bool playerFoxReached;
    public Vector3 checkpointPosition;

	// Use this for initialization
	void Start () {
        reached = false;
        playerWolfReached = false;
        playerFoxReached = false;
        checkpointPosition = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (playerFoxReached && playerWolfReached)
        {
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerFox") playerFoxReached = true;
        if (other.gameObject.name == "PlayerWolf") playerWolfReached = true;
    }

    public bool isReached()
    {
        return reached;
    }

}
