using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour {

    private bool toggled = false;
    private bool togglable = false;
    private SpriteRenderer mySprite;
    private SpriteRenderer playerSprite;
    private Transform door;

    // Use this for initialization
    void Start()
    {
        mySprite = GameObject.Find("Button").GetComponent<SpriteRenderer>();
        door = GameObject.Find("Environment").GetComponent<Transform>().Find("Door1");
    }
    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Player1Interact") && togglable)
        {
            toggled = !toggled;
        }

        if (toggled)
        {
            mySprite.color = new Color(0, 255, 0);
            door.GetComponent<Door1>().openDoor();
        }
        else
        {
            mySprite.color = new Color(255, 0, 0);
            door.GetComponent<Door1>().closeDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        togglable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        togglable = false;
    }
}
