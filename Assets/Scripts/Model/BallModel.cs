using UnityEngine;

public class BallModel : Part
{
    [SerializeField] private float _minVelocity = 5f;
    [SerializeField] private float _maxVelocity = 10f;
    [SerializeField] private Vector2 _initialForce;
    public Rigidbody2D rb { get; private set; }

    public new void Awake(){
        base.Awake();

        rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // (Should set an event)
        root.view.ballView.audioSource.Play();
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

    public float minVelocity => _minVelocity;
    public float maxVelocity => _maxVelocity;
    public Vector2 initialForce => _initialForce;
}