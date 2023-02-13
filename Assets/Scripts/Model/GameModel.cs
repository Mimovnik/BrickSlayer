using UnityEngine;

public class GameModel : Part
{
    public enum GameStatus
    {
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
        status = GameStatus.PAUSED;
    }

    public void startGame()
    {
        status = GameStatus.RUNNING;
        Time.timeScale = 1f;
    }

    public void endGame(GameStatus status)
    {
        Time.timeScale = 0f;
        this.status = status;
    }

}
