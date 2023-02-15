using System.Collections.Generic;
using UnityEngine;

public class Row : Part
{
    public List<Brick> bricks;

    public new void Awake()
    {
        base.Awake();

        bricks = new List<Brick>();
        bricks.AddRange(GetComponentsInChildren<Brick>());
    }

    public void Update()
    {
        bricks.RemoveAll(brick => brick == null);
    }
}