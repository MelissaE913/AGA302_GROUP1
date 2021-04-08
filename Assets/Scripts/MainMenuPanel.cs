using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : MenuPanel
{
    public void OnStageSelectPressed()
    {
        GameManager.instance.SetNextPhase(GameManager.GamePhases.LevelSelect);
    }
    public void OnOptionsPressed() { }
    public void OnCreditsPressed() { }
}
