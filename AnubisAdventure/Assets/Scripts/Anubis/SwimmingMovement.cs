using UnityEngine;

public class SwimmingMovement : MonoBehaviour
{

    public float swimForce = 2f; //Force applied
    public float maxSpeed = 3f; //Max swimming speed
    public float waterDrag = 2f; //Water resistance
    public float waterGravityScale = 0.5f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private float originalGravityScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        originalGravityScale = rb.gravityScale;
        rb.drag = waterDrag;
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 moveInput = new Vector2(moveX, moveY);
        if (moveInput.magnitude > 1)
        {
            moveInput.Normalize();
        }

        if (moveX != 0) 
        {
            spriteRenderer.flipX = (moveX < 0);
        }

        rb.AddForce(moveInput * swimForce);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    public void EnableSwimming()
    {
        Debug.Log("Swimming enabled");
        rb.gravityScale = waterGravityScale;
    }

    public void DisableSwimming()
    {
        rb.gravityScale = originalGravityScale;
    }
}