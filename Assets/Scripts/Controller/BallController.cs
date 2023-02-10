using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : Part
{
    public void OnTooSlow()
    {
        Vector2 velocity = root.view.ballView.rb.velocity;
        root.view.ballView.rb.velocity = velocity.normalized * root.model.ballModel.minVelocity;
    }

    public void OnTooFast()
    {
        Vector2 velocity = root.view.ballView.rb.velocity;
        root.view.ballView.rb.velocity = velocity.normalized * root.model.ballModel.maxVelocity;
    }

    public void OnCollision()
    {
        root.view.ballView.audioSource.Play();
    }
}