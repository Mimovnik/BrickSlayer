using UnityEngine;

public class Controller : Part
{
    [SerializeField] private BallController _ballController;
    [SerializeField] private PlatformController _platformController;
    [SerializeField] private GameController _gameController;

    public BallController ballController => _ballController;
    public PlatformController platformController => _platformController;
    public GameController gameController => _gameController;
}