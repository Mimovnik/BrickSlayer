using UnityEngine;

public class Controller : Part
{
    [SerializeField] private PlatformController _platformController;

    public PlatformController platformController => _platformController;
}