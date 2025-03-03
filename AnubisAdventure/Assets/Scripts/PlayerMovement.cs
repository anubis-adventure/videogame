using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody2d;
    private Transform transform;
    private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        if (move != 0)
        {
            rigidBody2d.velocity = new Vector2(speed * move, rigidBody2d.velocity.y);
            if (move < 0)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            else
            {

                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);

            }
        }
        float jump = Input.GetAxis("Jump");
        if (jump > 0 && CheckGround.isGrounded)
        {
            rigidBody2d.velocity = new Vector2(rigidBody2d.velocity.x, speed);

        }

    }
}