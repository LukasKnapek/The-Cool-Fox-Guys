using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    private bool toggled = false;
    private bool togglable = false;
    private SpriteRenderer mySprite;
    private SpriteRenderer playerSprite;
    private List<Transform> controlledObjects;

    // Use this for initialization
    void Start()
    {
        // Load the button sprite
        mySprite = GetComponent<SpriteRenderer>();
        GameMaster GM = GameMaster.GM;

        // Find and load all objects this particular button controls
        
        controlledObjects = new List<Transform>();
        foreach (string controlledObject in GM.ControlBindings[this.name])
        {
            controlledObjects.Add(GameObject.Find("Environment").GetComponent<Transform>().Find(controlledObject));
        }
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
            foreach (Transform controlledObject in controlledObjects)
            {
                controlledObject.GetComponent<DoorScript>().makeActive();
            }
            
        }
        else
        {
            mySprite.color = new Color(255, 0, 0);
            foreach (Transform controlledObject in controlledObjects)
            {
                Debug.Log(controlledObject);
                controlledObject.GetComponent<DoorScript>().makeNonActive();
            }
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
