using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAttack : MonoBehaviour
{
    public GameObject prefab;
    //public Animator animator;

    private void OnEnable()
    {
        ScratchSpawnController.OnShoot += Shoot;
    }

    private void OnDisable()
    {
        ScratchSpawnController.OnShoot -= Shoot;
    }

    public void Init()
    {
        ScratchSpawnController.OnShoot += Shoot;
    }

    public void Shoot()
    {
        print("ESTÁ DISPARANDOOOOOOOOOOOOOOO AAAAAAAAAAAAAAAAAAAAAAAAAA!!!!!!!!!!!!!!!!!!!111");
        Debug.Log(name + " ESTÁ DISPARANDOOOOOOOOOOOOOOO AAAAAAAAAAAAAAAAAAAAAAAAAA!!!!!!!!!!!!!!!!!!!111");
        Vector2 offset2D = Random.insideUnitCircle;
        Vector3 randomPos = transform.position + new Vector3(offset2D.x, offset2D.y, 0);


        GameObject instance = Instantiate(prefab, randomPos, Quaternion.identity);

        ScratchSpawnController scratch = instance.GetComponent<ScratchSpawnController>();
        if (scratch != null)
        {
            scratch.PerformAttack();
        }
    }

    void Start()
    {
        //if (animator == null)
        //    animator = GetComponent<Animator>();

        if (prefab == null)
            Debug.LogWarning("Prefab no asignado en spawnAttack de " + name);
    }
}
