using UnityEngine;

public class GameModel : Part
{
    public enum GameStatus
    {
        NOTSTARTED,
        PAUSED,
        RUNNING,
        WON,
        LOST
    }
    public GameStatus status;

    public new void Awake()
    {
        base.Awake();

        Time.timeScale = 0f;
        status = GameStatus.NOTSTARTED;
    }

    public void startGame()
    {
        status = GameStatus.RUNNING;
        Time.timeScale = 1f;
    }

    public void pauseGame()
    {
        status = GameStatus.PAUSED;
        Time.timeScale = 0f;
    }

    public void endGame(GameStatus status)
    {
        Time.timeScale = 0f;
        this.status = status;
    }

    public void Update()
    {
        if (root.model.brickContainer.bricksLeft <= 0)
        {
            endGame(GameModel.GameStatus.WON);
        }

        if (root.model.ballModel == null)
        {
            endGame(GameModel.GameStatus.LOST);
        }
    }
}
