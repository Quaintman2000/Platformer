using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxHP;
    private Transform tf;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator;

    /// <summary>
    /// The movement speed of the player.
    /// </summary>
    public float MovementSpeed = 5;
    /// <summary>
    /// The amount of force applied vertially when jumping.
    /// </summary>
    public float jumpForce = 10;
    public Transform groundPoint;
    public bool isGrounded = false;
    public int additionalJumps = 1;


    // Start is called before the first frame update
    void Start()
    {
        //grab needed components
        tf = gameObject.GetComponent<Transform>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();

        //check if the theres already a player
        if (GameManager.instance.playerTransform != null)
        {
            Debug.LogError("Had a duplicate player!");
            //destroy duplicate
            Destroy(this.gameObject);
        }
        //if there is more than two players
        else
        {
            //set the only player to be the main player
            GameManager.instance.playerTransform = this.gameObject.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //move the player on the x axis by determined speed
        float xMovement = Input.GetAxis("Horizontal") * MovementSpeed;
        rb2d.velocity = new Vector2(xMovement, rb2d.velocity.y);

        //if moving to the left while on the ground
        if (xMovement > 0 && isGrounded == true)
        {
            sr.flipX = false;
            animator.Play("PlayerWalk");
        }
        //when not on the ground
        else if (xMovement > 0)
        {
            sr.flipX = false;
        }
        //if moving right while on the ground
        else if (xMovement < 0 && isGrounded == true)
        {
            sr.flipX = true;
            animator.Play("PlayerWalk");
        }
        //when not on the ground
        else if (xMovement < 0)
        {
            sr.flipX = true;
        }
        //when no moving
        else
        {
            animator.Play("PlayerIdle");
        }

        //send a raycast to see if the player is close enough to the ground to be consider "grounded"
        RaycastHit2D hitInfo = Physics2D.Raycast(groundPoint.position, Vector2.down, 0.1f);
        //if on the groud
        if (hitInfo.collider != null)
        {
            isGrounded = true;
            //replenish the extra jumps
            additionalJumps = 1;
        }
        //if not on the ground
        else
        {
            isGrounded = false;
        }
        // when i press the spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if on the ground or has one extra jump
            if (isGrounded == true || additionalJumps != 0)
            {
                //if in the air,
                if (isGrounded == false)
                {
                    //subtract an additional jump
                    additionalJumps--;
                    //set y velocity = 0 so you jump the same height for your second jump
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    //add upward force set by the designer to "jump"
                    rb2d.AddForce(Vector2.up * jumpForce);
                }
                //if on the ground
                else
                {
                    //add upward force set by the designer to "jump"
                    rb2d.AddForce(Vector2.up * jumpForce);
                }
            }
        }
    }
}
