using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private Vector2 initialForce;
    [SerializeField] private float minVelocity = 5f;
    [SerializeField] private float maxVelocity = 10f;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnEnable()
    {
        rb.AddForce(initialForce);
    }

    public void FixedUpdate()
    {
        if (rb.velocity.magnitude < minVelocity)
        {
            rb.velocity = rb.velocity.normalized * minVelocity;
        }

        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }

}
