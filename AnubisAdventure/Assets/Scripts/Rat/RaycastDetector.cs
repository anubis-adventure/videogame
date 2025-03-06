using UnityEngine;

public class RaycastDetector : MonoBehaviour
{
    public EnemyPatrol enemy;
    public float raycastDistance = 1.7f;
    public LayerMask layerMask;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<EnemyPatrol>();
    }

    void Update()
    {
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance, layerMask);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Raycast hit: " + hit.collider.name);
                Debug.Log("Point of impact: " + hit.point);
                animator.SetTrigger("attack");
                enemy.speed = 4;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        Gizmos.DrawRay(transform.position, direction * raycastDistance);
    }
}
