using UnityEngine;

public class AIPlatformController : Part 
{
    public void FixedUpdate()
    {
        Rigidbody2D platformRigidbody = root.model.platformModel.rb;
        platformRigidbody.MovePosition(new Vector2(root.model.ballModel.rb.position.x, platformRigidbody.position.y));
    }
}
