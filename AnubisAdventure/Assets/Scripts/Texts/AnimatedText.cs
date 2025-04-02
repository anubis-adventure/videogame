using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class AnimatedText : MonoBehaviour
{
    public TMP_Text animatedText;

    public float zoomDuration = 0.4f;
    public float vanishDuration = 1f;

    public Vector3 startScale = new Vector3(0.1f, 0.1f, 0.1f);
    public Vector3 targetScale = Vector3.one;

    public float delayBeforeFade = 0.5f;

    private Coroutine currentAnimation;

    public void ShowAnimatedText()
    {
        animatedText.gameObject.SetActive(true);

        // Stop already running animations
        if (currentAnimation != null)
        {
            StopCoroutine(currentAnimation);
        }

        //Reset
        animatedText.transform.localScale = startScale;
        Color originalColor = animatedText.color;
        animatedText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);

        //Start animation
        currentAnimation = StartCoroutine(AnimateText());
    }

    private IEnumerator AnimateText()
    {
        //Zoom in
        float timer = 0f;
        while (timer < zoomDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / zoomDuration);
            animatedText.transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        //Delay
        yield return new WaitForSeconds(delayBeforeFade);

        //Fade out
        timer = 0f;
        Color originalColor = animatedText.color;
        while (timer < vanishDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / vanishDuration);
            float alpha = Mathf.Lerp(1f, 0f, t);
            animatedText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        //Disable
        animatedText.gameObject.SetActive(false);
    }
}
