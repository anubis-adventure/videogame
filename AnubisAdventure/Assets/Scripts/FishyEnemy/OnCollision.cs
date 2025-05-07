using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColli : MonoBehaviour
{

    public GameController controller;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.TakeDamage();
        }
    }
}
