using UnityEngine;

public class DestroyEverythingOnTouch : MonoBehaviour
{
    [SerializeField] private Collider2D destroyingCollider;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider == destroyingCollider)
        {
            Destroy(collision.gameObject);
        }
    }
}
