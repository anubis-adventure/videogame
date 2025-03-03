using UnityEngine;

public class CheckGround : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool isGrounded;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}