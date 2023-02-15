using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Part
{
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

    public void endGame(GameModel.GameStatus status)
    {
        Time.timeScale = 0f;
        root.model.gameModel.status = status;
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
