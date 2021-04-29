using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTempo;
    public float scrollSpeed = 0f;
    public bool hasStarted;
    //public Vector3 scrollDirection = Vector3.down;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.selectedSong != null) { beatTempo = GameManager.instance.selectedSong.bpm; }
            else
            {
                NoteSpawner ns = GetComponent<NoteSpawner>();
                if (ns)
                {
                    if (ns.DEBUG_songInfo != null)
                    {
                        beatTempo = GetComponent<NoteSpawner>().DEBUG_songInfo.bpm;
                    }
                }
            }
        }
        else
        {
            NoteSpawner ns = GetComponent<NoteSpawner>();
            if (ns)
            {
                if (ns.DEBUG_songInfo != null)
                {
                    beatTempo = GetComponent<NoteSpawner>().DEBUG_songInfo.bpm;
                }
            }
        }
        scrollSpeed = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            //has started gets changed to true by GAMEMANAGER
        }
        else
        {
            Vector3 dir = transform.up * -1f; //move down RELATIVE to rotoation
            transform.position += dir * (scrollSpeed * Time.deltaTime);//new Vector3(0f, beatTempo * Time.deltaTime, 0); 
        }
    }
}
