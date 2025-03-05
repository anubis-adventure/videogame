using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public float moveSpeed = 3f;
    public float jumpForce = 5f;

    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("move", move);

        //Assign velocity in Y axis to the fall float for animator.
        animator.SetFloat("fall", rigidBody2d.velocity.y);

        if (move != 0)
        {
            rigidBody2d.velocity = new Vector2(moveSpeed * move, rigidBody2d.velocity.y);


            spriteRenderer.flipX = (move < 0);
        }
        else
        {

            rigidBody2d.velocity = new Vector2(0, rigidBody2d.velocity.y);
        }

        // Salto
        bool jump = Input.GetButtonDown("Jump");
        if (jump && CheckGround.isGrounded)
        {
            rigidBody2d.velocity = new Vector2(rigidBody2d.velocity.x, jumpForce);
        }
    }
}
