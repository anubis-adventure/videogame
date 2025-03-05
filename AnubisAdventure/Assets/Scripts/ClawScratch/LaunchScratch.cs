using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScratch : MonoBehaviour
{
    public float scratchForce = 10f;
    private Rigidbody2D rb;
    public bool facingLeft = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        if(facingLeft)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScratchPoint")) {
            Vector2 forceDirection = new Vector2(transform.right.x, 0);
            rb.AddForce(forceDirection * scratchForce);
        }
    }
}
