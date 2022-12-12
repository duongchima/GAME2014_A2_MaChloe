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

    public Vector2 velocity;
    public float gravity;
    public float maxXVelocity;
    public float maxAcceleration;
    public float acceleration;
    public float distance = 0;
    public float maxJumpForce;
    public float currentJumpForce = 0f;
    public float maxJumpHeight;
    public Vector3 startPos;
    public Transform groundPoint;
    public float groundRadius;
    public LayerMask groundLayerMask;
    public bool isGrounded = false;

    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 1f;
    public float jumpTimeHeld = 0.0f;

    public float jumpGroundThreshold = 2;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
  
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        var hit = Physics2D.OverlapCircle(groundPoint.position, groundRadius, groundLayerMask);
        isGrounded = hit;
        Jump();
        //if (!isGrounded)
        //{
        //    if (isHoldingJump)
        //    {
        //        jumpTimeHeld += Time.fixedDeltaTime;
        //        if (jumpTimeHeld >= maxHoldJumpTime)
        //        {
        //            isHoldingJump = false;
        //        }
        //    }
        //    if (!isHoldingJump)
        //    {
        //        velocity.y += gravity * Time.fixedDeltaTime;
        //    }
        //}

        Move();
    }
    private void Move()
    {
        distance += velocity.x * Time.fixedDeltaTime;
        if (isGrounded)
        {
            float velocityRatio = velocity.x / maxXVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio);
            velocity.x += acceleration * Time.fixedDeltaTime;

            if (velocity.x >= maxXVelocity)
            {
                velocity.x = maxXVelocity;
            }
        }
    }
    void Jump()
    {
        //if(Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    if ((isGrounded) && (touch.phase == TouchPhase.Began))
        //    {
        //        if (!isHoldingJump)
        //        {
        //            isHoldingJump = true;
        //        }
        //    }
        //    else if(touch.phase == TouchPhase.Ended)
        //    {
        //        isHoldingJump = false;
        //    }
        //}
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isGrounded)
        {
            currentJumpForce = maxJumpForce;

            isHoldingJump = true;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            currentJumpForce = 0f;
            isHoldingJump = false;
        }
        if (isHoldingJump && transform.position.y - startPos.y < maxJumpHeight)
        {
            rigidbody2D.AddForce(Vector2.up * currentJumpForce, ForceMode2D.Impulse);
        }
        //else
        //{
        //    currentJumpForce = 0f;
        //}
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundPoint.position, groundRadius);
    }
}
