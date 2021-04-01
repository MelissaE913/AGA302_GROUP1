using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    public Text buttonText;
    public Button buttonElement;
    public Image buttonImage;
    public SongInfo buttonSongInfo;
    public LevelSelectPanel levelSelectPanel;

    private void Awake()
    {
        if (buttonText && buttonSongInfo)
        {
            buttonText.text = buttonSongInfo.songName;
        }
    }

    public void OnButtonPressed()
    {
        if (levelSelectPanel != null)
        {
            levelSelectPanel.ReportSongInfoButtonPressed(buttonSongInfo);
        }
    }
}
