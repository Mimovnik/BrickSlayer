using UnityEngine;
using TMPro;

public class UI : Part
{
    [SerializeField] private GameObject tipScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject pauseScreen;

    public new void Awake()
    {
        base.Awake();

        tipScreen.SetActive(true);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        pauseScreen.SetActive(false);
        root.model.gameModel.statusChange += statusChangeListener;
    }

    public void statusChangeListener(object sender, GameStatusEventArgs args)
    {
        switch (args.status)
        {
            case GameModel.GameStatus.NOTSTARTED:
                tipScreen.SetActive(true);
                break;
            case GameModel.GameStatus.RUNNING:
                tipScreen.SetActive(false);
                pauseScreen.SetActive(false);
                break;
            case GameModel.GameStatus.PAUSED:
                pauseScreen.SetActive(true);
                break;
            case GameModel.GameStatus.WON:
                winScreen.SetActive(true);
                break;
            case GameModel.GameStatus.LOST:
                loseScreen.SetActive(true);
                break;
        }
    }
}