using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmGamePanel : MenuPanel
{
    public Text scoreText;
    public Text multiText;

    private void Update()
    {
        if (GameManager.instance)
        {
            //note, we should really only do this when the score updates.  Not every frame.
            multiText.text = "Multiplier: x" + GameManager.instance.currentMultiplier;
            scoreText.text = "Score: " + GameManager.instance.currentScore;
        }
    }
}
