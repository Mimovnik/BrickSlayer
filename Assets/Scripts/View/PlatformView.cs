using UnityEngine;

public class PlatformView : Part
{
    public Rigidbody2D rb { get; private set; }

    public new void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody2D>();
        rb.mass = root.model.platformModel.mass;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Ball"))
        {
            root.controller.platformController.OnCollisionWithBall();
        }
    }
}
