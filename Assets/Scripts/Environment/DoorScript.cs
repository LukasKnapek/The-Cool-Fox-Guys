using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    private bool open = false;
    private SpriteRenderer mySprite;
    private Collider2D myCollider;  

    // Use this for initialization
    void Start () {
        mySprite = this.GetComponent<SpriteRenderer>();
        myCollider = this.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (open)
        {
            myCollider.isTrigger = true;
            mySprite.enabled = false;
        }
        else {
            myCollider.isTrigger = false;
            mySprite.enabled = true;
        }
    }

    public void makeActive()
    {
        open = true;
    }

    public void makeNonActive()
    {
        open = false;
    }
}
