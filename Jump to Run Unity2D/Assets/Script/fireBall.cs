using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireBall : MonoBehaviour
{
    public playerControl playercontroll;
    public Transform firePoint;
    public GameObject fire;

    bool fireEnable = true;
    float fireCountTime = 0.2f;
    float fireCounter;
    public float fireTime;
    bool lockButton = false;

    public Slider fire_slider;

    public AudioSource fireSound;

    private void Start()
    {
        fire_slider.maxValue = fireTime;
        fire_slider.value = fireTime;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && fireEnable == true && lockButton == false)
        {
            fireCounter = fireCountTime;
            lockButton = true;
            fire_slider.value -= 1.5f;
            Instantiate(fire, firePoint.position, Quaternion.identity);
            fireSound.Play();


            if (fire_slider.value < 1.5)
            {
                fireEnable = false;
            }
        }

        if(fire_slider.value < fire_slider.maxValue)
        {
            fire_slider.value += Time.deltaTime / 3.5f;
        }

        if (fire_slider.value >= 1.5)
        {
            fireEnable = true;
        }

        if (fireCounter > 0)
        {
            fireCounter -= Time.deltaTime;
        }
        else
        {
            lockButton = false;
        }

    }

}
