using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTempo;
    public bool hasStarted;
    //public Vector3 scrollDirection = Vector3.down;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            Vector3 dir = transform.up * -1f; //move down RELATIVE to rotoation
            transform.position += dir * (beatTempo * Time.deltaTime);//new Vector3(0f, beatTempo * Time.deltaTime, 0); 
        }
    }
}
