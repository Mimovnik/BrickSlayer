using UnityEngine;

public class View : Part
{
    [SerializeField] private BallView _ballView;
    [SerializeField] private PlatformView _platformView;

    public BallView ballView => _ballView;

    public PlatformView platformView => _platformView;
}