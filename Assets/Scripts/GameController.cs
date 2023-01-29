using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject tipScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private TMP_Text brickCounterDisplay;
    [SerializeField] private GameObject bricksParent;
    private bool gameStarted = false;

    public void Awake()
    {
        Time.timeScale = 0f;
        tipScreen.SetActive(true);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    public void startGame()
    {
        gameStarted = true;
        Time.timeScale = 1f;
        tipScreen.SetActive(false);
    }

    private void endGame(bool won)
    {
        Time.timeScale = 0f;
        if (won)
        {
            winScreen.SetActive(true);
        }
        else
        {
            loseScreen.SetActive(true);
        }
    }

    public void Update()
    {

        int brickCount = bricksParent.transform.childCount;

        brickCounterDisplay.SetText("Bricks left: " + brickCount);

        if(brickCount <= 0){
            endGame(true);
        }

        if(ball == null){
            endGame(false);
        }
    }

    public bool isGameStarted()
    {
        return gameStarted;
    }
}
