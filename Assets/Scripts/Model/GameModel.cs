using UnityEngine;
using System;

public class GameModel : Part
{
    [SerializeField] private int _currentLevel;

    public enum GameStatus
    {
        NOTSTARTED,
        PAUSED,
        RUNNING,
        WON,
        LOST
    }
    public GameStatus status;
    private GameStatus previousStatus;

    public delegate void GameStatusEventHandler(object sender, GameStatusEventArgs args);
    public event GameStatusEventHandler statusChange;

    public int currentLevel => _currentLevel;

    public new void Awake()
    {
        base.Awake();

        previousStatus = status;

        if (status == GameStatus.NOTSTARTED)
        {
            Time.timeScale = 0f;
        }
    }

    public void Update()
    {
        if (root.model.brickContainer.bricksLeft <= 0 && status != GameStatus.WON)
        {
            status = GameStatus.WON;
        }

        if (root.model.ballModel == null && status != GameStatus.LOST)
        {
            status = GameStatus.LOST;
        }

        if (previousStatus != status)
        {
            statusChange?.Invoke(this, new GameStatusEventArgs(status));
        }
        previousStatus = status;
    }
}

public class GameStatusEventArgs
{
    public GameModel.GameStatus status { get; }
    public GameStatusEventArgs(GameModel.GameStatus status) { this.status = status; }
}
