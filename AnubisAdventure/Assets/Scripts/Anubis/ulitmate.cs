using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ulitmate : MonoBehaviour
{
    public GameObject cat;
    public float spawnRadius = 5f;
    bool thrown = false;

    void Update()
    {
        bool ulti = Input.GetKeyDown(KeyCode.L);

        if (ulti && !thrown)
        {
            int hearts = (int)PStats.Instance.Health;
            for (int i = 0; i < (7 - hearts); i++)
            {
                Debug.Log(i + " generando clon");

                Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
                randomPos.y = transform.position.y;

                Instantiate(cat, randomPos, Quaternion.identity);
                GameObject clone = Instantiate(cat, randomPos, Quaternion.identity);
                spawnAttack sa = clone.GetComponent<spawnAttack>();
                if (sa != null) sa.Init();
                else Debug.Log("sa es nulo");
            }

            thrown = true;
        }
    }
}
