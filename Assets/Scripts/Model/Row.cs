using System.Collections.Generic;
using UnityEngine;

public class Row : Part
{
    public List<Brick> bricks;

    public void Update(){
        bricks.RemoveAll(brick => brick == null);
    }
}