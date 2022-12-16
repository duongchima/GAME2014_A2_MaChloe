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
    public float maxJumpHeightCap;
    public float maxJumpHeight;
    public Vector3 startPos;
    public Transform groundPoint;
    public float groundRadius;
    public LayerMask groundLayerMask;
    public bool isGrounded = false;

    public bool isHoldingJump = false;

    public float jumpGroundThreshold = 2;

    public Animator animator;
    public PlayerAnimState playerAnimState;
    private Rigidbody2D rigidbody2D;
    SoundManager soundManager;

    private void Awake()
    {
  
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        soundManager = FindObjectOfType<SoundManager>();
        animator = GetComponent<Animator>();
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

        Move();
    }
    private void Move()
    {
        distance += velocity.x * Time.fixedDeltaTime;
        if (isGrounded)
        {
            ChangeAnimation(PlayerAnimState.RUN);
            float velocityRatio = velocity.x / maxXVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio);
            maxJumpHeight = maxJumpHeightCap * velocityRatio;
            velocity.x += acceleration * Time.fixedDeltaTime;

            if (velocity.x >= maxXVelocity)
            {
                velocity.x = maxXVelocity;
            }
        }
    }
    void Jump()
    {
      
        if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) && isGrounded)
        {
            soundManager.PlaySoundFX(Sound.JUMP, Channel.PLAYER_SOUND_FX);
            ChangeAnimation(PlayerAnimState.JUMP);
            currentJumpForce = maxJumpForce;
            isHoldingJump = true;
        }
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            currentJumpForce = 0f;
            isHoldingJump = false;
            ChangeAnimation(PlayerAnimState.FALL);
        }
        if (isHoldingJump && transform.position.y - startPos.y < maxJumpHeight)
        {
            rigidbody2D.AddForce(Vector2.up * currentJumpForce, ForceMode2D.Impulse);
        }

    }

    public void Restart()
    {
        transform.position = startPos;
        distance = 0;
        velocity = new Vector2(0, 0);
    }

    private void ChangeAnimation(PlayerAnimState animationState)
    {
        playerAnimState = animationState;
        animator.SetInteger("AnimationState", (int)playerAnimState);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundPoint.position, groundRadius);
    }
}
