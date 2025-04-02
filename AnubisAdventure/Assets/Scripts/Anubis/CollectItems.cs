using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    private bool _hasSnorkel = false;
    public TimerController timer;
    public AnimatedText animatedText;

    public bool HasSnorkle
    {
        get
        {
            return _hasSnorkel;
        }
        set
        {
            _hasSnorkel = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snorkel"))
        {
            _hasSnorkel = true;
            Destroy(collision.gameObject);

            //Shows the animated text
            animatedText.ShowAnimatedText();

            //Adds time
            timer.AddTime(7.5f);
        }
    }

    
}
