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

    public LaunchScratch launchScratch;
    public Transform scratchSpawnPoint;

    private Vector3 spawnPointOriginalLocalPos;

    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if (scratchSpawnPoint != null) //The og position of the scratch spawn point
        {
            spawnPointOriginalLocalPos = scratchSpawnPoint.localPosition;
        }
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

            //Change the rotation of the scratch
            if (launchScratch != null)
            {
                launchScratch.facingLeft = (move < 0);
            }

            //Change the position of the scratch spawn point
            if (scratchSpawnPoint != null)
            {
                if (move < 0)
                {
                    scratchSpawnPoint.localPosition = new Vector3(-Mathf.Abs(spawnPointOriginalLocalPos.x), spawnPointOriginalLocalPos.y, spawnPointOriginalLocalPos.z);
                }
                else
                {
                    scratchSpawnPoint.localPosition = new Vector3(Mathf.Abs(spawnPointOriginalLocalPos.x), spawnPointOriginalLocalPos.y, spawnPointOriginalLocalPos.z);
                }
            }
        }
        else
        {

            rigidBody2d.velocity = new Vector2(0, rigidBody2d.velocity.y);
        }

        // Salto
        float jump = Input.GetAxis("Jump");
        if (jump > 0 && CheckGround.isGrounded)
        {
            rigidBody2d.velocity = new Vector2(rigidBody2d.velocity.x, jumpForce);
        }
    }
}
