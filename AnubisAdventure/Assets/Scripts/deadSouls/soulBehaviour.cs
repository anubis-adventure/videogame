using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soulBehaviour : MonoBehaviour
{
    public AIPath aiPath;

    void Start()
    {
        aiPath = GetComponent<AIPath>();
        if (aiPath == null)
        {
            Debug.LogError("AIPath no encontrado en " + gameObject.name);
        }
    }


    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
