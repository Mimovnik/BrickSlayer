using UnityEngine;

public class DestroyingEdge : Part
{
    private Collider2D destroyingCollider;

    public new void Awake()
    {
        base.Awake();

        destroyingCollider = GetComponent<EdgeCollider2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider == destroyingCollider)
        {
            Destroy(collision.gameObject);
        }
    }
}
