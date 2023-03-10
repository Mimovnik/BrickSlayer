using UnityEngine;
using System;

public class BallModel : Part
{
    [SerializeField] private float _minVelocity = 5f;
    [SerializeField] private float _maxVelocity = 10f;
    [SerializeField] private Vector2 _initialForce;
    public Rigidbody2D rb { get; private set; }
    public Vector2 enterVelocity { get; private set; }
    public event EventHandler collisionEnter;

    public new void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        rb.AddForce(initialForce);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        collisionEnter?.Invoke(this, EventArgs.Empty);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        enterVelocity = rb.velocity;
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