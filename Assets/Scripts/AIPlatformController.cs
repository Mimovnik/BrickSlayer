using UnityEngine;

public class AIPlatformController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ball;
    private Rigidbody2D rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        rb.MovePosition(new Vector2(ball.position.x, rb.position.y));
    }
}
