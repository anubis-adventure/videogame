using UnityEngine;

public class OnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�La rata ha tocado al jugador!");
            // Por ejemplo, podr�as llamar a una funci�n para reducir la salud del jugador:
            // player.GetComponent<PlayerHealth>().TakeDamage(10);
            PStats.Instance.TakeDamage(1);
        }
    }
}
