using UnityEngine;

public class PlatformModel : Part
{
    public int ballTouches { get; private set; } = 0;
    public Rigidbody2D rb { get; private set; }

    public new void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Ball"))
        {
            ballTouches++;
        }
    }

}
