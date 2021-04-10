using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void OnPlayQuitPressed()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnPlayQuitPressed();
        }
    }
    public void OnStartGamePressed()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnStartGamePressed();
        }
    }

    public void OnPlayExitPressed()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnPlayExitPressed();
        }
    }

    public void OnPlayOptionsPressed()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnPlayOptionsPressed();
        }
    }

    public void TriggerPause(bool isPaused)
    {
        if (GameManager.instance != null)
        {
            if (isPaused)
            { GameManager.instance.OnPaused(); }
            else
            { GameManager.instance.OnUnPaused(); }
        }
    }
}
