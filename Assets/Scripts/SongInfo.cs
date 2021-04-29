using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SongInfo", menuName = "Song/InfoObject")]
public class SongInfo : ScriptableObject
{
    public string songName;
    public string artist;
    public float duration;
    public AudioClip musicClip;
    public Sprite albumCover;
    public GameObject songNotesPrefab;
    public int bpm = 120;
}
