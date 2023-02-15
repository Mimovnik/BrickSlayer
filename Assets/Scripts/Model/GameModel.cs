using UnityEngine;

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

    public int currentLevel => _currentLevel;

    public new void Awake()
    {
        base.Awake();

        if (status == GameStatus.NOTSTARTED)
        {
            Time.timeScale = 0f;
        }
    }

    public void Update()
    {
        if (root.model.brickContainer.bricksLeft <= 0)
        {
            // Should expose an event
            root.controller.gameController.endGame(GameModel.GameStatus.WON);
        }

        if (root.model.ballModel == null)
        {
            // Should expose an event
            root.controller.gameController.endGame(GameModel.GameStatus.LOST);
        }
    }
}
