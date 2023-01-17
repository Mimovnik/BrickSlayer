using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialForce: MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private Vector2 force;
    public void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(force);
    }
}
