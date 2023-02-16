using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Part
{
    public new void Awake()
    {
        base.Awake();

        root.model.gameModel.statusChange += endGame;
    }
    public void startGame()
    {
        root.model.gameModel.status = GameModel.GameStatus.RUNNING;
        Time.timeScale = 1f;
    }

    public void pauseGame()
    {
        root.model.gameModel.status = GameModel.GameStatus.PAUSED;
        Time.timeScale = 0f;
    }

    public void endGame(object sender, GameStatusEventArgs args)
    {
        if (args.status == GameModel.GameStatus.WON || args.status == GameModel.GameStatus.LOST)
        {
            Time.timeScale = 0f;
        }
    }

    public void loadLevel(int num)
    {
        SceneManager.LoadScene("Level" + num);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene("Level" + root.model.gameModel.currentLevel);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
