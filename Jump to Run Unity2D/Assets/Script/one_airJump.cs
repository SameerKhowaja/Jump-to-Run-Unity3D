using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class one_airJump : MonoBehaviour
{
    public Rigidbody2D player_RB;
    public Slider airjumper_Slider;
    public Animator doubleJump_Animation;

    float Jump_Force;
    bool lockButton;
    bool isJumpingTwice;

    void Start()
    {
        Jump_Force = 7f;
        lockButton = false;
        isJumpingTwice = false;

        airjumper_Slider.value = airjumper_Slider.maxValue;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && airjumper_Slider.value >= 3 && lockButton == false)
        {
            player_RB.velocity = Vector2.up * Jump_Force;
            airjumper_Slider.value -= 3;

            isJumpingTwice = true;
            lockButton = true;
            doubleJump_Animation.SetBool("isJumpingTwice", isJumpingTwice);
        }
        else
        {
            isJumpingTwice = false;
            doubleJump_Animation.SetBool("isJumpingTwice", isJumpingTwice);
        }

        if (airjumper_Slider.value < airjumper_Slider.maxValue)
        {
            airjumper_Slider.value += Time.deltaTime / 2f;
        }

        if(lockButton == true)
        {
            StartCoroutine(unlockButton());
        }
    }
    
    IEnumerator unlockButton()
    {
        yield return new WaitForSeconds(0.5f);
        lockButton = false;
    }

}
