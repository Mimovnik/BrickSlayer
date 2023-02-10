using UnityEngine;

public class GameModel : Part
{
    [SerializeField] private float _firstRowHeight;
    public bool gameStarted = false;
    public int brickCount;
    public bool rowMovingDown = false;
    public Transform firstRow;

    public float firstRowHeight => _firstRowHeight;

    public void Start()
    {
        brickCount = GameObject.FindGameObjectsWithTag("Brick").Length;
    }
}
