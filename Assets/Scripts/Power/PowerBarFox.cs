using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarFox : MonoBehaviour
{
    private float power = 1f;

    // Update is called once per frame
    void Update()
    {
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

    public float getPower()
    {
        return power;
    }
}
