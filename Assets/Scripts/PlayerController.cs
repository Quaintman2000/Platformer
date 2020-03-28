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
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal") * MovementSpeed;
        rb2d.velocity = new Vector2(xMovement, rb2d.velocity.y);

        if (xMovement > 0)
        {
            sr.flipX = false;
            animator.Play("PlayerWalk");
        }
        else if (xMovement < 0)
        {
            sr.flipX = true;
            animator.Play("PlayerWalk");
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
        }
        else
        {
            isGrounded = false;
        }
        // jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
        }
    }

    void OnDestroy()
    {

    }
}
