using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float lifetime =1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);

    }
}
