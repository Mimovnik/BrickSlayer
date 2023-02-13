using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : Part
{
    [SerializeField] private GameObject tipScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    public new void Awake()
    {
        base.Awake();

        tipScreen.SetActive(true);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }



}
