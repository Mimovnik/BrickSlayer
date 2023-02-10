using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformModel : Part
{
    [SerializeField] private float _sensitivity = 100f;
    [SerializeField] private float _mass = 100f;
    [SerializeField] private PlayerInput _playerInput;
    public int ballTouches = 0;

    public float sensitivity => _sensitivity;

    public float mass => _mass;

    public PlayerInput playerInput => _playerInput;
}
