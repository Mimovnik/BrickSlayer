using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : Part
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject tipScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private Transform bricks;

    public new void Awake()
    {
        base.Awake();
        Time.timeScale = 0f;
        tipScreen.SetActive(true);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    public void startGame()
    {
        root.model.gameModel.gameStarted = true;
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
        return root.model.gameModel.firstRow.transform.childCount <= 0;
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

        if (root.model.gameModel.firstRow == null)
        {
            root.model.gameModel.firstRow = bricks.GetChild(bricks.childCount - 1);
        }

        if (isFirstRowCleared())
        {
            Destroy(root.model.gameModel.firstRow.gameObject);
            root.model.gameModel.rowMovingDown = true;
        }

        if (root.model.gameModel.brickCount <= 0)
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

        if (root.model.gameModel.rowMovingDown)
        {
            moveBricksDown(0.01f);
        }
        if (root.model.gameModel.firstRow.position.y <= root.model.gameModel.firstRowHeight)
        {
            root.model.gameModel.rowMovingDown = false;
        }
    }

    public void decrementBrickCount()
    {
        root.model.gameModel.brickCount--;
    }

    public bool isGameStarted()
    {
        return root.model.gameModel.gameStarted;
    }
}
