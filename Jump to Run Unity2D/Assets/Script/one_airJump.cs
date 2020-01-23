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

    bool isGrounded;
    public Transform feetPos;
    public Transform centerPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Start()
    {
        Jump_Force = 7f;
        lockButton = false;
        isJumpingTwice = false;

        airjumper_Slider.value = airjumper_Slider.maxValue;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        //KeyBoard Inputs
        if (Input.GetKey(KeyCode.A) && airjumper_Slider.value >= 3 && lockButton == false && isGrounded == false)
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
        //---------------------------------------------------------------------

        //Mobile Input
        if(Input.touchCount > 1)
        {
            Touch touch2 = Input.GetTouch(1);
            Vector3 touch_pos2 = Camera.main.ScreenToWorldPoint(touch2.position);
            touch_pos2.z = 0;

            if ((touch_pos2.x > centerPos.transform.position.x))
            {
                if (airjumper_Slider.value >= 3 && lockButton == false && isGrounded == false)
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
            }
        }
        else if (Input.touchCount > 0 && Input.touchCount < 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Vector3 touch_pos1 = Camera.main.ScreenToWorldPoint(touch1.position);
            touch_pos1.z = 0;

            if ((touch_pos1.x > centerPos.transform.position.x) && (touch_pos1.y < centerPos.transform.position.y))
            {
                if (airjumper_Slider.value >= 3 && lockButton == false && isGrounded == false)
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
            }
        }
        //-------------------------------------------------------------------

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
