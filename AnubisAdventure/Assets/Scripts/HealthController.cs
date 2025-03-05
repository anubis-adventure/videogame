using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private int lives;
    private int hits;
    void Start()
    {
        lives = 7;
        hits = 2;
    }

    void UpdateAnubisLife()
    {
        lives -= 1;
    }

    void UpdateAnubisHits()
    {
        hits -= 1;
    }
}
