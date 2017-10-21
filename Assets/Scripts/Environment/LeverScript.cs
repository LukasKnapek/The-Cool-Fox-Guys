using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour {

    private bool toggled = false;
    private bool togglable = false;
    private SpriteRenderer mySprite;
    private SpriteRenderer playerSprite;
    private List<Transform> controlledObjects;

    // Use this for initialization
    void Start () {
        mySprite = GetComponent<SpriteRenderer>();
        GameMaster GM = GameMaster.GM;

        controlledObjects = new List<Transform>();
        foreach (string controlledObject in GM.ControlBindings[this.name])
        {
            controlledObjects.Add(GameObject.Find("Environment").GetComponent<Transform>().Find(controlledObject));
        }
    }

    // Update is called once per frame
    void Update () {

        if ((Input.GetButtonDown("Player1Interact") || Input.GetButtonDown("Player2Interact")) && togglable)
        {
            toggled = !toggled;
        }

        if (toggled)
        {
            foreach (Transform controlledObject in controlledObjects)
            {
                controlledObject.GetComponent<DoorScript>().makeActive();
            }
            mySprite.sprite = Resources.Load("Sprites/lever_on", typeof(Sprite)) as Sprite;
        }
        else
        {
            foreach (Transform controlledObject in controlledObjects)
            {
                controlledObject.GetComponent<DoorScript>().makeNonActive();
            }
            mySprite.sprite = Resources.Load("Sprites/lever_off", typeof(Sprite)) as Sprite;
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
