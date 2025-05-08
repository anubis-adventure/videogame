using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhaleBehaviour : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRadius = 5f;
    public float minDelay = 1f;
    public float maxDelay = 3f;
    public int whaleLifePoints = 15;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (whaleLifePoints > 0)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
            randomPos.y = 0f;
            Instantiate(prefab, randomPos, Quaternion.identity);
            if (animator != null)
            {
                animator.SetTrigger("attack");
                yield return new WaitForSeconds(1);
                animator.SetTrigger("idle");
            }
        }
    }

    public void TakeDamage()
    {
        whaleLifePoints--;
        Debug.Log("vida del cetaceo " + whaleLifePoints);
        if (whaleLifePoints <= 0)
        {
            Die();
        }
    }

    public int GetDamageDone()
    {
        return whaleLifePoints;
    }

    private void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("die");
            StartCoroutine(DestroyAfterAnimation());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

        //Cambiar a escena final
        SceneManager.LoadScene("final_cutscene", LoadSceneMode.Single);
    }
}
