using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
//[RequireComponent(typeof(Animator))]

public class PlayerJump1 : MonoBehaviour
{
    //force, apply force, 1x
    //rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    [Header("Jump Details")]

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;

    [Header("Ground Details")]
    [SerializeField] private Transform groundcheck;
    [SerializeField] private float rad0Circle;
    [SerializeField] private LayerMask whatIsGround;
    public bool grounded;

    [Header("Components")]
    private Rigidbody2D rb;
    //private Animator myAnimator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //myAnimator = GetComponent<myAnimator>();
        jumpTimeCounter = jumpTime;
    }

    //myAnimator.SetBool("landing", true);
    //myAnimator.SetBool("landing", false);

    //myAnimator.SetTrigger("jump");
    //myAnimator.ResetTrigger("jump");

    private void Update()
    {
        //what it means to be grounded
        grounded = Physics2D.OverlapCircle(groundcheck.position, rad0Circle, whatIsGround);

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            //myAnimator.ResetTrigger("jump");
            //myAnimator.SetBool("landing", false);
        }

        //if we press the jump button
        if (Input.GetButtonDown("jump") && grounded)
        {
            //jump!
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            stoppedJumping = false;
            //tell the animator to play jump animation
            //myAnimator.SetTrigger("jump");
        }

        //if we hold the jump button
        if (Input.GetButton("jump") && !stoppedJumping && (jumpTimeCounter > 0))
        {
            //jump!
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTimeCounter -= jumpTime.deltaTime;
            //myAnimator.SetTrigger("jump");
        }

        //if we release the jump button
        if (Input.GetButtonUp("jump"))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
            //myAnimator.SetBool("landing", true);
            //myAnimator.ResetTrigger("jump");
        }

        //if (rb.velocity.y < 0)
        {
            //myAnimator.SetBool("landing", true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundcheck.position, rad0Circle);
    }

    private void FixedUpdate()
    {
        HandleLayers();
    }

    //private void HandleLayers()
    
       // if (!grounded)
        
            //myAnimator.SetLayerWeight(1, 1);
        
        //else
        
           //myAnimator.SetLayerWeight(1, 0);
        
    }
}
