using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickContainer : Part
{
    [SerializeField] private List<Row> rows;
    private Row firstRow = null;
    private bool rowMovingDown = false;
    [SerializeField] private float firstRowHeight;
    public int bricksLeft { get; private set; }

    public new void Awake()
    {
        base.Awake();

        bricksLeft = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    public void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }

        if (firstRow == null)
        {
            firstRow = getFirstRow();
        }

        if (firstRow.bricks.Count <= 0)
        {
            rows.Remove(firstRow);
            Destroy(firstRow.gameObject);
            rowMovingDown = true;
        }
    }

    private Row getFirstRow()
    {
        Row lowest = null;
        float minHeight = int.MaxValue;
        foreach (Row row in rows)
        {
            float y = row.transform.position.y;
            if (y < minHeight)
            {
                lowest = row;
                minHeight = y;
            }
        }
        return lowest;
    }

    public List<Brick> getAllBricks()
    {
        List<Brick> bricks = new List<Brick>();

        foreach (Row row in rows)
        {
            bricks.AddRange(row.bricks);
        }
        return bricks;
    }

    public void FixedUpdate()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }

        if (rowMovingDown)
        {
            moveRowsDown(0.01f);
        }
        if (firstRow != null && firstRow.transform.position.y <= firstRowHeight)
        {
            rowMovingDown = false;
        }
    }

    private void moveRowsDown(float distance)
    {
        foreach (Row row in rows)
        {
            Vector2 newPosition = row.transform.position;
            newPosition.y -= distance;
            row.transform.position = newPosition;
        }
    }

    public void decrementBrickCount()
    {
        bricksLeft--;
    }
}
