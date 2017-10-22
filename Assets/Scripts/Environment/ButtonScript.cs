using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public bool buttonIsOn = false;
    private bool togglableWolf = false;
    private bool togglableFox = false;
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

        if ((Input.GetButtonDown("Player1Interact") && togglableFox) || (Input.GetButtonDown("Player2Interact") && togglableWolf))
        {
            buttonIsOn = !buttonIsOn;
            this.GetComponent<AudioSource>().Play();
        }

        if (buttonIsOn)
        {
            foreach (GameObject controlledObject in controlledObjects)
            {
                if (controlledObject.name.Contains("Bridge"))
                {
                    Debug.Log(controlledObject.GetComponent<Animator>().enabled + ":" + controlledObject.GetComponent<BoxCollider2D>().enabled);
                    if (controlledObject.GetComponent<Animator>().enabled == false || controlledObject.GetComponent<BoxCollider2D>().enabled == false)
                    {
                        controlledObject.GetComponent<Animator>().enabled = true;
                        controlledObject.GetComponent<BoxCollider2D>().enabled = true;
                        controlledObject.GetComponent<AudioSource>().Play();
                    }

                }
                controlledObject.gameObject.SetActive(true);
            }
            mySprite.sprite = Resources.Load("Sprites/button_off", typeof(Sprite)) as Sprite;
        }
        else
        {
            foreach (GameObject controlledObject in controlledObjects)
            {
                if (controlledObject.name.Contains("Bridge"))
                {
                    controlledObject.GetComponent<Animator>().enabled = false;
                    controlledObject.GetComponent<BoxCollider2D>().enabled = false;

                }
                controlledObject.gameObject.SetActive(false);

            }
            mySprite.sprite = Resources.Load("Sprites/button_on", typeof(Sprite)) as Sprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerFox") togglableFox = true;
        else if (collision.gameObject.name == "PlayerWolf") togglableWolf = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerFox") togglableFox = false;
        else if (collision.gameObject.name == "PlayerWolf") togglableWolf = false;
    }
}
