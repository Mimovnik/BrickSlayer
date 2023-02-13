using UnityEngine;

public class Model : Part
{
    [SerializeField] private BallModel _ballModel;
    [SerializeField] private PlatformModel _platformModel;
    [SerializeField] private GameModel _gameModel;
    [SerializeField] private BrickContainer _brickContainer;

    public BallModel ballModel => _ballModel;
    public PlatformModel platformModel => _platformModel;
    public GameModel gameModel => _gameModel;
    public BrickContainer brickContainer => _brickContainer;
}
