using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Player Behaviour
Name: Chloe Ma 
Student #: 101260013
Date last modified: 20/11/22
Description: Controls the Player's movement and behaviours.
 */
public class PlayerBehaviour : MonoBehaviour
{
    //[SerializeField] private GameObject gameover;

    public float gravity;
    public Vector2 velocity;
    public float maxXVelocity = 100;
    public float maxAcceleration = 10;
    public float acceleration;
    public float distance = 0;
    public float jumpVelocity;
    public float groundHeight = 10;
    public bool isGrounded = false;

    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float jumpTimeHeld = 0.0f;

    public float jumpGroundThreshold = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    gameover.SetActive(true);
        //}
        Vector2 pos = transform.position;
       float groundDistance = Mathf.Abs(pos.y - groundHeight);
        if (isGrounded || groundDistance <= jumpGroundThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                jumpTimeHeld = 0.0f;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        if (!isGrounded)
        {
            if (isHoldingJump)
            {
                jumpTimeHeld += Time.fixedDeltaTime;
                if(jumpTimeHeld >= maxHoldJumpTime)
                {
                    isHoldingJump = false;
                }
            }
            pos.y += velocity.y * Time.fixedDeltaTime;
            if (!isHoldingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }

            if(pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded = true;
                jumpTimeHeld = 0.0f;
            }
        }

        distance += velocity.x * Time.fixedDeltaTime;

        if (isGrounded)
        {
            float velocityRatio = velocity.x / maxXVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio);
            velocity.x += acceleration * Time.fixedDeltaTime;

            if(velocity.x >= maxXVelocity)
            {
                velocity.x = maxXVelocity;
            }
        }


        transform.position = pos;
    }
}
