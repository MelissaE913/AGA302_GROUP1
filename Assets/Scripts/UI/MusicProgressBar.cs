using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicProgressBar : MonoBehaviour
{
    public RectTransform meter;

    void Update()
    {
        if (GameManager.instance != null)
        {
            meter.localScale = new Vector3(1f, GameManager.instance.currentProgress, 1f);
        }    
    }

}
