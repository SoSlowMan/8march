using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    public float lifetime;

    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
