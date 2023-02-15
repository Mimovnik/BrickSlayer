using UnityEngine;

public class Brick : Part
{
    [SerializeField] private Vector2 initialForce;
    [SerializeField] private bool willMove = false;
    [SerializeField] public int maxDurability = 1;
    [SerializeField] public BrickType type;
    protected Rigidbody2D rb;
    public int durability { get; private set; }
    public enum BrickType
    {
        DIRT,
        STONE,
        RED_BRICK,
        STONE_BRICK,
        LEAF
    }

    public new void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        durability = maxDurability;
        if (!willMove)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
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
        if (durability <= 0)
        {
            root.model.brickContainer.decrementBrickCount();
            Destroy(gameObject);
        }
    }
}
