using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    private bool toggled = false;
    private bool togglable = false;
    private SpriteRenderer mySprite;
    private SpriteRenderer playerSprite;
    private List<GameObject> controlledObjects;

    // Use this for initialization
    void Start()
    {
        // Load the button sprite
        mySprite = GetComponent<SpriteRenderer>();
        GameMaster GM = GameMaster.GM;

        // Find and load all objects this particular button controls
        
        controlledObjects = new List<GameObject>();
        foreach (string controlledObject in GM.ControlBindings[this.name])
        {
            controlledObjects.Add(GameObject.Find("Environment").GetComponent<Transform>().Find(controlledObject).gameObject);
        }
    }
    // Update is called once per frame
    void Update() {

        if ((Input.GetButtonDown("Player1Interact") || Input.GetButtonDown("Player2Interact")) && togglable)
        {
            toggled = !toggled;
            this.GetComponent<AudioSource>().Play();
        }

        if (toggled)
        {
            foreach (GameObject controlledObject in controlledObjects)
            {
                controlledObject.SetActive(false);
            }
            mySprite.sprite = Resources.Load("Sprites/button_on", typeof(Sprite)) as Sprite;
        }
        else
        {
            foreach (GameObject controlledObject in controlledObjects)
            {
                controlledObject.SetActive(true);
            }
            mySprite.sprite = Resources.Load("Sprites/button_off", typeof(Sprite)) as Sprite;
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
