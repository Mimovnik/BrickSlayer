using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private Vector2 initialForce;
    [SerializeField] private bool willMove = false;
    [SerializeField] private int maxDurability = 1;
    [SerializeField] private Sprite brokenSprite;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private int durability;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        durability = maxDurability;
        if (!willMove)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public void OnEnable()
    {
        rb.AddForce(initialForce);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Ball"))
        {
            takeDamage(collision.collider.attachedRigidbody);
        }
    }

    protected virtual void takeDamage(Rigidbody2D ball)
    {
        durability--;
        if (maxDurability > 1)
        {
            spriteRenderer.sprite = brokenSprite;
        }
        if (durability <= 0)
        {
            Destroy(gameObject);
        }
    }
}
