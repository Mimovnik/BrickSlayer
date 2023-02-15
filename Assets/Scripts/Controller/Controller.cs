using UnityEngine;

public class Controller : Part
{
    [SerializeField] private PlatformController _platformController;
    [SerializeField] private GameController _gameController;

    public PlatformController platformController => _platformController;
    public GameController gameController => _gameController;
}