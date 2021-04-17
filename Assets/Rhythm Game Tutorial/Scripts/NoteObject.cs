using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

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
                gameObject.SetActive(false);
               // GameManager.instance.NoteHit();
               if (Mathf.Abs(transform.position.y) > 0.25)
                {
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                } else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                } else
                {
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                }
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
            GameManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);

        }
        }
    
}
