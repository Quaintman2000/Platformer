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

    public float MaxHP
    {
        get
        {
            return maxHP;
        }
        private set
        {
            maxHP = value;
            if (maxHP <= 0)
            {
                maxHP = 1;
                Debug.LogWarning("[PlayerController] attempted to set maxHP lower than or equal to 0.");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();

        if (GameManager.instance.playerTransform != null)
        {
            Debug.LogError("Had a duplicate player!");
            Destroy(this.gameObject);
        }
        else
        {
            GameManager.instance.playerTransform = this.gameObject.transform;
        }
    }
        // Update is called once per frame
        void Update()
    {
        float xMovement = Input.GetAxis("Horizontal") * MovementSpeed;
        rb2d.velocity = new Vector2(xMovement, rb2d.velocity.y);
        //if moving and on the ground
        if (xMovement > 0 && isGrounded == true)
        {
            sr.flipX = false;
            animator.Play("PlayerWalk");
        }
        else if(xMovement > 0)
        {
            sr.flipX = false;
        }
        else if (xMovement < 0 && isGrounded == true)
        {
            sr.flipX = true;
            animator.Play("PlayerWalk");
        }
        else if(xMovement < 0)
        {
            sr.flipX = true;
        }
        else
        {
            animator.Play("PlayerIdle");
        }
        // if the player is on the ground

        RaycastHit2D hitInfo = Physics2D.Raycast(groundPoint.position, Vector2.down, 0.1f);
        if (hitInfo.collider != null)
        {
            isGrounded = true;
            //replenish the extra jumps
            additionalJumps = 1;
        }
        else
        {
            isGrounded = false;
        }
        // jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if on the ground or has one extra jump
            if (isGrounded == true || additionalJumps != 0)
            {
                //if in the air, take a away an extra jump
                if (isGrounded == false)
                {
                    additionalJumps--;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpForce);
                }
                else
                {
                    rb2d.AddForce(Vector2.up * jumpForce);
                    
                }

            }
            
        }
        
    }

}
