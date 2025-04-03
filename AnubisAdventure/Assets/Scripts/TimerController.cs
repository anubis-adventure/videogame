using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float currentTime = 30f;
    public TMP_Text timerText;
    public GameController gameController;
    public Animator animator;

    private float dieCooldown = 1.5f;
    private float dieTimer = 0f;

    void Update()
    {
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0f);

        if (currentTime <= 0f)
        {
            // Increment dieTimer when time is 0
            dieTimer += Time.deltaTime;
            if (dieTimer >= dieCooldown)
            {
                gameController.Die();
                currentTime = 30f;
                dieTimer = 0f; // Reset timer
            }
        }
        else
        {
            // Reset timer if is greater than 0
            dieTimer = 0f;
        }

        timerText.text = "Time Left: " + Mathf.Ceil(currentTime).ToString();
    }

    private void FixedUpdate()
    {
        if (currentTime <= 0f) 
        {
            animator.SetBool("lostSnorkel", true);
        }
        else
        {
            animator.SetBool("lostSnorkel", false);
        }
    }

    public void AddTime(float additionalTime)
    {
        currentTime += additionalTime;
    }

    public void SetTime(float time)
    {
        currentTime = time;
    }
}
