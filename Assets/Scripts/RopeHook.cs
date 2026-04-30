using UnityEngine;

[RequireComponent(typeof(DistanceJoint2D))]
public class RopeHook : MonoBehaviour
{
    public float maxDistance = 8f;
    public LayerMask hookMask;
    public LineRenderer line;

    DistanceJoint2D joint;
    Rigidbody2D rb;

    void Awake()
    {
        joint = GetComponent<DistanceJoint2D>();
        rb = GetComponent<Rigidbody2D>();
        joint.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = (mouse - (Vector2)transform.position).normalized;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, maxDistance, hookMask);
            if (hit)
            {
                joint.connectedAnchor = hit.point;
                joint.distance = Vector2.Distance(transform.position, hit.point);
                joint.enabled = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
        }

        // วาดเชือก
        if (joint.enabled)
        {
            line.positionCount = 2;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, joint.connectedAnchor);
        }
        else
        {
            line.positionCount = 0;
        }
    }

    void FixedUpdate()
    {
        if (!joint.enabled) return;

        // เสริม Rotational (centripetal) เพื่ออธิบายฟิสิกส์
        Vector2 dir = (Vector2)joint.connectedAnchor - rb.position;
        float r = dir.magnitude;
        float v = rb.linearVelocity.magnitude;
        if (r > 0.01f)
        {
            float centripetal = (rb.mass * v * v) / r; // F = mv^2/r
            rb.AddForce(dir.normalized * centripetal * Time.fixedDeltaTime);
        }
    }
}