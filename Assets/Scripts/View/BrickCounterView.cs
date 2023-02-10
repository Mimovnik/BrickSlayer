using UnityEngine;
using TMPro;

public class BrickCounterView : Part
{
    [SerializeField] private TMP_Text text;

    public void Update()
    {
        if (text == null)
        {
            return;
        }
        text.SetText("Bricks left: " + root.model.gameModel.brickCount);
    }
}
