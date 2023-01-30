using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject tipScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private TMP_Text brickCounterDisplay;
    [SerializeField] private Transform bricks;
    [SerializeField] private float firstRowHeight;
    private Transform firstRow;
    private bool gameStarted = false;
    private int brickCount;
    private bool rowMovingDown = false;

    public void Awake()
    {
        Time.timeScale = 0f;
        tipScreen.SetActive(true);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    public void Start()
    {
        brickCount = GameObject.FindGameObjectsWithTag("Brick").Length;
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

    private bool isFirstRowCleared()
    {
        return firstRow.transform.childCount <= 0;
    }

    private void moveBricksDown(float distance)
    {
        foreach (Transform row in bricks)
        {
            Vector2 newPosition = row.position;
            newPosition.y -= distance;
            row.position = newPosition;
        }
    }

    public void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }
        brickCounterDisplay.SetText("Bricks left: " + brickCount);

        if (firstRow == null)
        {
            firstRow = bricks.GetChild(bricks.childCount - 1);
        }

        if (isFirstRowCleared())
        {
            Destroy(firstRow.gameObject);
            rowMovingDown = true;
        }

        if (brickCount <= 0)
        {
            endGame(true);
        }

        if (ball == null)
        {
            endGame(false);
        }
    }

    public void FixedUpdate()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }
        
        if (rowMovingDown)
        {
            moveBricksDown(0.01f);
        }
        if (firstRow.position.y <= firstRowHeight)
        {
            rowMovingDown = false;
        }
    }

    public void decrementBrickCount()
    {
        brickCount--;
    }

    public bool isGameStarted()
    {
        return gameStarted;
    }
}
