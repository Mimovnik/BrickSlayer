using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : Button
{
    protected override void OnClick()
    {
        root.controller.gameController.restartLevel();
    }
}
