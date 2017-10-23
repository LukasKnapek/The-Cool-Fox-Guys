using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointScript : MonoBehaviour {

    public bool reached;
    private bool playerWolfReached;
    private bool playerFoxReached;

    public Vector3 checkpointPosition;

    private Slider powerBarFox;
    private Slider powerBarWolf;

    public static float foxBarValue, wolfBarValue;

    // Use this for initialization
    void Start () {
        playerWolfReached = false;
        playerFoxReached = false;

        checkpointPosition = this.gameObject.transform.position;
        powerBarFox = FindObjectOfType<PowerBarFox>().GetComponent<Slider>();
        powerBarWolf = FindObjectOfType<PowerBarWolf>().GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {

        if (playerFoxReached && playerWolfReached)
        {
            this.GetComponent<SpriteRenderer>().color = Color.green;

            //foxBarValue = powerBarFox.value;
            //wolfBarValue = powerBarWolf.value;
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerFoxMove>()) playerFoxReached = true;
        if (other.GetComponent<PlayerWolfMove>()) playerWolfReached = true;
    }

    public bool isReached()
    {
        return playerFoxReached && playerWolfReached;
    }

}
