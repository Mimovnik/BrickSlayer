using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    [SerializeField] private Collider2D destroyingCollider;
    [SerializeField] private bool destroyMeNotOthers = true;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (destroyMeNotOthers)
        {
            Destroy(gameObject);
        }
        else if(collision.otherCollider == destroyingCollider)
        {
            Destroy(collision.gameObject);
        }
    }
}
