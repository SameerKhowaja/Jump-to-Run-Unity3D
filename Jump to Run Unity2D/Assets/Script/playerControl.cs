using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public Rigidbody2D Player_RB;
    public Animator Player_animator;
    public float Speed;
    public float Jump_Force;

    bool isGrounded;
    public Transform feetPos;
    public Transform centerPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    bool gotHit = false;
    bool isTrue = false;
    float fallPos;

    float jumpTimeCounter;
    public float jumpTime;
    bool isJumping;

    public BaseSpawnner groundScript;
    public fireBall fireball;
    public BaseSpawnner basespawner;
    public gameManager gameControl;

    public GameObject HitParticle_Effect;

    public AudioSource fallSound, HitSound;

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        //jump for Keyboard Input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            Player_RB.velocity = Vector2.up * Jump_Force;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping==true)
        {
            if (jumpTimeCounter > 0)
            {
                Player_RB.velocity = Vector2.up * Jump_Force;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        //------------------------------------------------------------
        

        //jump for Mobile Inputs
        if (Input.touchCount > 0)
        {
            Touch touch1 = Input.GetTouch(0);
            Vector3 touch_pos = Camera.main.ScreenToWorldPoint(touch1.position);
            touch_pos.z = 0;

            if((touch_pos.x < centerPos.transform.position.x))
            {
                //Debug.Log(touch_pos);
                if ((touch1.phase == TouchPhase.Began) && isGrounded == true)
                {
                    isJumping = true;
                    jumpTimeCounter = jumpTime;
                    Player_RB.velocity = Vector2.up * Jump_Force;
                }

                if (isJumping == true)
                {
                    if (jumpTimeCounter > 0)
                    {
                        Player_RB.velocity = Vector2.up * Jump_Force;
                        jumpTimeCounter -= Time.deltaTime;
                    }
                    else
                    {
                        isJumping = false;
                    }
                }

                if (touch1.phase == TouchPhase.Ended)
                {
                    isJumping = false;
                }
            }
            
        }
        //-----------------------------------------------------------

        fallPos = transform.position.y;
        if (fallPos < -1.5)
        {
            gotHit = true;
            if (isTrue == true)
            {
                Player_RB.velocity = Vector2.up * 2f;
                isTrue = false;
                Player_RB.velocity = Vector2.down;
            }
        }

        Player_animator.SetFloat("Speed", Speed);
        Player_animator.SetFloat("fallPos", fallPos);
        Player_animator.SetBool("gotHit", gotHit);
        Player_animator.SetBool("isGrounded", isGrounded);

        if (gotHit == true) //Fall from Ground
        {
            Jump_Force = Speed = 0;
            groundScript.enabled = false;
            fireball.enabled = false;
            basespawner.enabled = false;
            gameControl.enabled = true;

            Player_RB.constraints = RigidbodyConstraints2D.FreezeAll;
            fallSound.Play();
            this.enabled = false;
        }

    }

    void FixedUpdate()
    {
        //run
        Player_RB.velocity = new Vector2(Speed, Player_RB.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            Debug.Log("Hit");
            gotHit = true;
            Player_animator.SetBool("gotHit", gotHit);
            Jump_Force = Speed = 0;
            groundScript.enabled = false;
            fireball.enabled = false;
            basespawner.enabled = false;
            gameControl.enabled = true;

            Instantiate(HitParticle_Effect, transform.position, Quaternion.identity);
            HitSound.Play();
            fallSound.mute = true;

            Player_RB.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

}
