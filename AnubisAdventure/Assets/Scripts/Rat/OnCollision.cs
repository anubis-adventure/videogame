using UnityEngine;

public class OnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("¡La rata ha tocado al jugador!");
            PStats.Instance.TakeDamage(1);
        }
    }
}
