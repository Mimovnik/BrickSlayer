using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : Button
{
    protected override void OnClick()
    {
        root.controller.gameController.startGame();
    }
}
