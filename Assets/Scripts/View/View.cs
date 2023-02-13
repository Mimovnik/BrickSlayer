using UnityEngine;

public class View : Part
{
    [SerializeField] private BallView _ballView;

    public BallView ballView => _ballView;
}