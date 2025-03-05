using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchSpawnController : MonoBehaviour
{
    public GameObject clawScratch;
    public Transform spawnPoint;
    public Animator animator;
    public float attackDuration = 0.25f;
    private bool canAttack = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool scratch = Input.GetKeyDown(KeyCode.C);

        //This creates the claw scratch in the fixed position
        if (scratch && canAttack) {
            StartCoroutine(PerformAttack());
        }
    }

    IEnumerator PerformAttack()
    {
        animator.SetBool("attack", true);
        canAttack = false;

        yield return new WaitForSeconds(attackDuration);
        // Instantiate the scratch attack
        Instantiate(clawScratch, spawnPoint.position, spawnPoint.rotation);

        animator.SetBool("attack", false);
        canAttack = true;
    }
}
