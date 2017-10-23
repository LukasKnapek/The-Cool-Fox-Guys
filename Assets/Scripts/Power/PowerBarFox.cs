using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarFox : MonoBehaviour {

    private float power = 1f;

    private void Awake()
    {
        GetComponent<Slider>().value = power;
    }

    public void increasePower(float amount)
    {
        power += amount;
        GetComponent<Slider>().value = power;

    }

    public void decreasePower(float amount)
    {
        power -= amount;
        GetComponent<Slider>().value = power;

    }

    public float getPower()
    {
        return power;
    }
}
