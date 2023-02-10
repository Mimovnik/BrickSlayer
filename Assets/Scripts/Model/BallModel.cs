using UnityEngine;

public class BallModel : Part
{
    [SerializeField] private float _minVelocity = 5f;
    [SerializeField] private float _maxVelocity = 10f;
    [SerializeField] private Vector2 _initialForce;
    [SerializeField] private float _mass = 1f;

    public float minVelocity => _minVelocity;
    public float maxVelocity => _maxVelocity;
    public Vector2 initialForce => _initialForce;
    public float mass => _mass;
}