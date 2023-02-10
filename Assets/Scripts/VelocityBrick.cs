using UnityEngine;

public class VelocityBrick : Brick
{
    [SerializeField] private float velocityThreshold;
    [SerializeField] private bool greaterToDestroy = true;
    protected override void takeDamage(Rigidbody2D ball)
    {
        float fromBallToBrickX = rb.position.x - ball.position.x;
        if (ball.velocity.x > 0)
        {
            fromBallToBrickX += 0.5f;
        }
        else
        {
            fromBallToBrickX -= 0.5f;
        }
        bool ballMovingTowardsBrick = Mathf.Sign(ball.velocity.x) == Mathf.Sign(fromBallToBrickX);
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
