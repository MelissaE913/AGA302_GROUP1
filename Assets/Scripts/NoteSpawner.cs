using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public SongInfo DEBUG_songInfo;

    void Start()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.selectedSong != null)
            {
                SpawnSongInfoNotes(GameManager.instance.selectedSong);
            }
            else if (DEBUG_songInfo != null)
            {
                SpawnSongInfoNotes(DEBUG_songInfo);
            }
        }
        else if (DEBUG_songInfo != null)
        {
            SpawnSongInfoNotes(DEBUG_songInfo);
        }
    }

    void SpawnSongInfoNotes( SongInfo s )
    {
        if (s.songNotesPrefab != null)
        {
            GameObject instantiatedNotesPrefab = Instantiate(s.songNotesPrefab);
            instantiatedNotesPrefab.transform.SetParent(transform);
            instantiatedNotesPrefab.transform.localPosition = Vector3.zero;
            instantiatedNotesPrefab.transform.localRotation = Quaternion.identity;
            instantiatedNotesPrefab.transform.localScale = Vector3.one;
        }
        else
        {
            Debug.LogWarning("No song is in Song Info Slot for " + s.songName);
        }
    }
}
