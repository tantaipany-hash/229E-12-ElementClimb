using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AirDrag : MonoBehaviour
{
    public float k = 0.6f; // ค่าสัมประสิทธิ์

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 v = rb.linearVelocity;
        if (v.magnitude > 0.01f)
        {
            float drag = k * v.magnitude; // F ≈ kv
            rb.AddForce(-v.normalized * drag);
        }
    }
}