using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private Vector2 initialForce;
    [SerializeField] private bool willMove = false;
    private Rigidbody2D rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Start(){
        if(!willMove){
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
            destroyMe();
        }
    }

    private void destroyMe()
    {
        Destroy(gameObject);
    }
}
