using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : Button
{
    protected override void OnClick()
    {
        root.controller.gameController.loadMainMenu();
    }
}
