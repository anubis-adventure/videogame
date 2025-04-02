using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float currentTime = 30f;
    public TMP_Text timerText;

    void Update()
    {
        currentTime -= Time.deltaTime;

        currentTime = Mathf.Max(currentTime, 0f); //Min 0

        timerText.text = "Time Left: " + Mathf.Ceil(currentTime).ToString();
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
