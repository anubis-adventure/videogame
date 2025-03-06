using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnorkelController : MonoBehaviour
{
    public float amplitude = 0.1f; //how high
    public float frequency = 3f; //how fast

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Y offset based on sine wave
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        // offset to the og position
        transform.position = startPosition + new Vector3(0, yOffset, 0);
    }
}
