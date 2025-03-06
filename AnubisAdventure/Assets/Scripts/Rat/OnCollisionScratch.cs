using UnityEngine;

public class OnCollisionScratch : MonoBehaviour
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
            Debug.Log("¡El jugador golpeó la rata!");

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
        Destroy(gameObject);
    }

}
