using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : MenuPanel
{
    public void OnStageSelectPressed()
    {
        GameManager.instance.SetNextPhase(GameManager.GamePhases.LevelSelect);
    }
    public void OnOptionsPressed() 
    {
        GameManager.instance.SetNextPhase(GameManager.GamePhases.OptionsPhase);
    }

    public void OnPlayOptionsPressed()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnPlayOptionsPressed();
        }
    }

    public void OnCreditsPressed() { }
}
