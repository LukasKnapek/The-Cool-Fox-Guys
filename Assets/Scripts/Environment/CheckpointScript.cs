using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointScript : MonoBehaviour {

    public bool reached;
    private bool playerWolfReached;
    private bool playerFoxReached;
    private float playerWolfPower;
    private float playerFoxPower;

    public Vector3 checkpointPosition;

    private Slider powerBarFox;
    private Slider powerBarWolf;

    // Use this for initialization
    void Start () {
        playerWolfReached = false;
        playerFoxReached = false;

        checkpointPosition = this.gameObject.transform.position;
        powerBarFox = GameObject.Find("UI").GetComponent<Transform>().Find("PowerBarFox").GetComponent<Slider>();
        powerBarWolf = GameObject.Find("UI").GetComponent<Transform>().Find("PowerBarWolf").GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {

        if (playerFoxReached && playerWolfReached)
        {
            //playerWolfPower = powerBarWolf.value;
            //playerFoxPower = powerBarFox.value;
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerFox") playerFoxReached = true;
        if (other.gameObject.name == "PlayerWolf") playerWolfReached = true;
    }

    public bool isReached()
    {
        return playerFoxReached && playerWolfReached;
    }

}
