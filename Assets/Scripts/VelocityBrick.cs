using UnityEngine;

public class VelocityBrick : Brick
{
    [SerializeField] private float velocityThreshold;
    [SerializeField] private bool greaterToDestroy = true;
    protected override void takeDamage(Rigidbody2D ball)
    {
        if (greaterToDestroy && ball.velocity.magnitude > velocityThreshold)
        {
            base.takeDamage(ball);
        }
        if (!greaterToDestroy && ball.velocity.magnitude < velocityThreshold)
        {
            base.takeDamage(ball);
        }
    }
}
