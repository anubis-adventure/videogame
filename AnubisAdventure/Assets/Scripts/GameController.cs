using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 flagPosition;
    Rigidbody2D rb;
    int waterCounter = 0; //Created to prevent double execution for Die()

    private void Start()
    {
        flagPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            waterCounter++;
            if (waterCounter == 1) //Executes it only when it touches it only one time.
            {
                Die();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water")) //Reset the counter
        {
            waterCounter = 0;
        }
    }

    public void UpdateCheckpoint(Vector2 checkpointPosition)
    {
        flagPosition = checkpointPosition;
    }

    void Die()
    {
        //Remove a heart from the health whenever it dies from touching something like water
        PlayerStats.Instance.TakeDamage(1);
        StartCoroutine(Respawn(0.3f));
    }

    IEnumerator Respawn(float duration)
    {
        rb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = flagPosition;
    }
}