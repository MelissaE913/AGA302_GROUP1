using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController_Results : MenuController
{
    public Text perfectText, goodText, missedText, highComboText, scoreText;
    public Text songTitleText;
    public Text songDifficultyText;
    public Image songIcon;

    void Start()
    {
        if (GameManager.instance.selectedSong != null)
        {
            songIcon.sprite = GameManager.instance.selectedSong.albumCover;
            songTitleText.text = GameManager.instance.selectedSong.songName;
        }
        perfectText.text = GameManager.instance.perfectHits.ToString("00");
        goodText.text = GameManager.instance.goodHits.ToString("00");
        missedText.text = GameManager.instance.missedHiits.ToString("00");
        highComboText.text = GameManager.instance.multiplierTracker.ToString("00");
        scoreText.text = GameManager.instance.currentScore.ToString("00");
    }
}
