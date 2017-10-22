using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour {

    public static bool reached;
    public static Vector3 checkpointPosition;

	// Use this for initialization
	void Start () {
        reached = false;
        checkpointPosition = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (reached)
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
        Debug.Log("Triggered");
        if (other.gameObject.tag == "Player") reached = true;
    }

}
