using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleCollisionScratch : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Scratch"))
        {
            WhaleBehaviour whale = GetComponent<WhaleBehaviour>();
            Debug.Log("El gatico ataco al cetaceo");
            whale.TakeDamage();
            if (animator != null)
            {
                animator.SetTrigger("damage");
                new WaitForSeconds(2);
                animator.SetTrigger("idle");
            }
        }
    }
}
