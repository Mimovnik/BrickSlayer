using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallView : Part
{
    public Rigidbody2D rb { get; private set; }
    public AudioSource audioSource {get; private set;}

    public new void Awake()
    {
        base.Awake();

        audioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        rb.mass = root.model.ballModel.mass;

        rb.AddForce(root.model.ballModel.initialForce);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        root.controller.ballController.OnCollision();
    }

    public void FixedUpdate()
    {
        if (rb.velocity.magnitude < root.model.ballModel.minVelocity)
        {
            root.controller.ballController.OnTooSlow();
        }

        if (rb.velocity.magnitude > root.model.ballModel.maxVelocity)
        {
            root.controller.ballController.OnTooFast();
        }
    }
}
