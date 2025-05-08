using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishyColliScratch : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Scratch"))
        {
            Debug.Log("El gatico ataco el pez");

            if (animator != null)
            {
                animator.SetTrigger("die");
                StartCoroutine(DestroyAfterAnimation());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    System.Collections.IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(transform.root.gameObject);
    }
}
