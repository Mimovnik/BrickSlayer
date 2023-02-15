using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Button : Part 
{
    protected UnityEngine.UI.Button button;

    public new void Awake(){
        base.Awake();

        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(OnClick);
    }

    protected abstract void OnClick();
}