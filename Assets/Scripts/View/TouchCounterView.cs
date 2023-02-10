using UnityEngine;
using TMPro;

public class TouchCounterView : Part
{
    [SerializeField] private TMP_Text text;

    public void Update()
    {
        if (text == null)
        {
            return;
        }
        text.SetText("Touches: " + root.model.platformModel.ballTouches);
    }
}
