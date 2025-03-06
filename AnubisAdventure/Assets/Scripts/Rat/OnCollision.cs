using UnityEngine;

public class OnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("¡La rata ha tocado al jugador!");
            // Por ejemplo, podrías llamar a una función para reducir la salud del jugador:
            // player.GetComponent<PlayerHealth>().TakeDamage(10);
            PStats.Instance.TakeDamage(1);
        }
    }
}
