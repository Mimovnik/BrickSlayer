using UnityEngine;

public class VelocityBrick : Brick
{
    [SerializeField] private float velocityThreshold;
    [SerializeField] private bool greaterToDestroy = true;

    protected override void takeDamage(Rigidbody2D ball)
    {
        Vector2 enterVelocity = root.model.ballModel.enterVelocity;
        if (greaterToDestroy && enterVelocity.magnitude > velocityThreshold)
        {
            base.takeDamage(ball);
        }
        if (!greaterToDestroy && enterVelocity.magnitude < velocityThreshold)
        {
            base.takeDamage(ball);
        }
    }
}
