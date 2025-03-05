using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 flagPosition;
    Rigidbody2D rb;

    private void Start()
    {
        flagPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            Die();
        }
    }

    public void UpdateCheckpoint(Vector2 checkpointPosition)
    {
        flagPosition = checkpointPosition;
    }

    void Die()
    {
        StartCoroutine(Respawn(0.3f));
    }

    IEnumerator Respawn(float duration)
    {
        rb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = flagPosition;
    }
}