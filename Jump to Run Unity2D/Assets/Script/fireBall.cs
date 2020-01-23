using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireBall : MonoBehaviour
{
    public playerControl playercontroll;
    public Transform firePoint;
    public Transform centerPos;
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
        //KeyBoard Input
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
        //------------------------------------------------

        //Mobile Input
        if (Input.touchCount > 0)
        {
            Touch touch1 = Input.GetTouch(0);
            Vector3 touch_pos = Camera.main.ScreenToWorldPoint(touch1.position);
            touch_pos.z = 0;

            if ((touch_pos.x > centerPos.transform.position.x) && (touch_pos.y > centerPos.transform.position.y))
            {
                if (fireEnable == true && lockButton == false)
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
            }
        }
        //-----------------------------------------------

            if (fire_slider.value < fire_slider.maxValue)
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
