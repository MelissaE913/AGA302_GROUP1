using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelSelectPanel : MonoBehaviour
{
    public Text SongSelectionText;
    public SongInfo currentSongInfo;
    public int currentDifficultyLevel;
    public Button playLevelButton;

    public Button[] difficultyButtons;
    public Color difficultyActiveColor;
    public Color difficultyInactiveColor;

    private void Awake()
    {
        RefreshLevelSelectView();
    }

    public void ReportSongInfoButtonPressed(SongInfo info)
    {
        currentSongInfo = info;
        RefreshLevelSelectView();
    }
    public void ReportDifficultyButtonPressed(int difficultyLevel)
    {
        currentDifficultyLevel = difficultyLevel;
        RefreshLevelSelectView();
    }
    public void RefreshLevelSelectView()
    {
        if (currentSongInfo != null)
        {
            if (SongSelectionText != null)
                SongSelectionText.text = currentSongInfo.songName;
        }
        else
        {
            if (SongSelectionText != null)
                SongSelectionText.text = "";
        }
        bool isInteractable = (currentDifficultyLevel > 0) && (currentSongInfo != null);
        playLevelButton.interactable = isInteractable;

        for (int i = 0; i < difficultyButtons.Length; i++)
        {
            if ((i + 1) == currentDifficultyLevel)
            {
                difficultyButtons[i].GetComponent<Image>().color = difficultyActiveColor;
            }
            else
            {
                difficultyButtons[i].GetComponent<Image>().color = difficultyInactiveColor;
            }
        }
    }
}
