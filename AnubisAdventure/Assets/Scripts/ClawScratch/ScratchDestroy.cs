using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchDestroy : MonoBehaviour
{
    public Transform scratch;
    public float colissionRadius = 0f;
    public bool collided = false;
    public LayerMask whatToCollideWith;

    private void Update()
    {
        collided = Physics2D.OverlapCircle(scratch.position, colissionRadius, whatToCollideWith);

        if (collided) Destroy(gameObject); //In case it touches walls and ground
        if(!GetComponent<Renderer>().isVisible) Destroy(gameObject);
    }
}
