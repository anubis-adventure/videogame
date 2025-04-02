using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColli : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("El pececillo le hizo plop al gato");
            PStats.Instance.TakeDamage(1);
        }
    }
}
