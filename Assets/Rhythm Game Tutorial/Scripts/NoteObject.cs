using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    public bool hasMissed = false;
    public bool isLastNote = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                // GameManager.instance.NoteHit();
                if (Mathf.Abs(transform.localPosition.y) > 0.25)
                {
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                }
                else if (Mathf.Abs(transform.localPosition.y) > 0.05f)
                {
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                }
                else
                {
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                }
                gameObject.SetActive(false);

                if(isLastNote)
                    GameManager.instance.ReportLastNoteHit();
            }
        }
        else
        {
            if (hasMissed)
            {
                gameObject.SetActive(false);
                GameManager.instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);

                if (isLastNote)
                    GameManager.instance.ReportLastNoteHit();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            hasMissed = true;
        }
    }
    
}
