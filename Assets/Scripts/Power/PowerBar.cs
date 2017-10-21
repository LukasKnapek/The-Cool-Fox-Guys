using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

    private float power = 1f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Slider>().value = power;
    }

    public void increasePower(float amount)
    {
        power += amount;
    }

    public void decreasePower(float amount)
    {
        power -= amount;
    }
}
