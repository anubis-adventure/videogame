using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollissionFish : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fish"))
        {
            Debug.Log("El pececillo le hizo plop al gato");
            Destroy(transform.root.gameObject);
        }
    }
}
