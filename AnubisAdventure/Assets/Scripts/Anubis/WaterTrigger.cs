using UnityEngine;

public class WaterTrigger : MonoBehaviour
{

    public PlayerMovement normalMovementScript;
    public SwimmingMovement swimMovementScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SWater"))
        {
            //Enable swimming
            swimMovementScript.EnableSwimming();

            if (normalMovementScript != null)
                normalMovementScript.enabled = false;
            if (swimMovementScript != null)
                swimMovementScript.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SWater"))
        {
            //Disable swimming
            swimMovementScript.DisableSwimming();

            if (normalMovementScript != null)
                normalMovementScript.enabled = true;
            if (swimMovementScript != null)
                swimMovementScript.enabled = false;
        }
    }
}

