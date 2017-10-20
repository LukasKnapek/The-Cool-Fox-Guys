using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour {

    private bool toggled = false;
    private bool togglable = false;
    private SpriteRenderer mySprite;
    private SpriteRenderer playerSprite;

	// Use this for initialization
	void Start () {
       mySprite = GameObject.Find("Diamond").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Toggle") && togglable)
        {
            Debug.Log("Toggled!");
            toggled = !toggled;
        }

        if (toggled) mySprite.color = new Color(0, 255, 0);
        else mySprite.color = new Color(255, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        togglable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        togglable = false;
        Debug.Log("Out of trigger zone");
        Debug.Log(togglable);
    }
}
