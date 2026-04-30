using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpAccel = 18f; // a ใน F = ma
    public float airControl = 0.7f;
    public LayerMask groundMask;
    public Transform groundCheck;
    public float groundRadius = 0.1f;

    Rigidbody2D rb;
    bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ตรวจพื้น
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);

        // กระโดด (ใช้ F = m a)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            float mass = rb.mass;
            float force = mass * jumpAccel; // F = ma
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float control = isGrounded ? 1f : airControl;

        // คุมความเร็วแนวนอน
        float targetVx = h * moveSpeed;
        float vx = Mathf.Lerp(rb.linearVelocity.x, targetVx, 0.2f * control);
        rb.linearVelocity = new Vector2(vx, rb.linearVelocity.y);
    }
}