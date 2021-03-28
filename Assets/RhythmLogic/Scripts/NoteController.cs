using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    List<int> whichNote = new List<int>() { 1, 6, 3, 4, 2, 5, 2, 1, 2, 3, 5, 6, 4, 6, 5, 5, 1, 2, 4, 1, 1, 4, 5, 5 };

    public int noteMark = 0;

    public Transform noteObj;

    public string timerReset = "y";

    public float yPos;
    public Transform noteSpawnPivot;
    public Transform[] stringLocationPivots;

     // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator spawnNote()
    {
        yield return new WaitForSeconds(1);
        int currentNote = whichNote[noteMark];
        Debug.Log(currentNote);
        yPos = 0f;
        if (stringLocationPivots.Length > currentNote - 1 )
            yPos = stringLocationPivots[currentNote - 1].position.y;
        else { Debug.Log("Exceeded string array size."); }
        noteMark += 1;
        timerReset = "y";
        Instantiate(noteObj, new Vector3(noteSpawnPivot.position.x, yPos, noteSpawnPivot.position.z), noteObj.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerReset == "y")
        {
            StartCoroutine(spawnNote());
            timerReset = "n";
        }
    }
}
