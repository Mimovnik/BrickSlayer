using UnityEngine;

public class Model : Part
{
    [SerializeField] private BallModel _ballModel;
    [SerializeField] private PlatformModel _platformModel;
    [SerializeField] private GameModel _gameModel;

    public BallModel ballModel => _ballModel;
    public PlatformModel platformModel => _platformModel;
    public GameModel gameModel => _gameModel;
}
