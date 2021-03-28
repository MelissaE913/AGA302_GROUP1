using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    float speed = 1f;
    void Update()
    {
        transform.position += Vector3.right * (Time.deltaTime * speed);
    }
}
