using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            ShipController.instance.counter++;
            AudioController.instance.PlayExplosionSound();
            Destroy(gameObject);
        }        
    }

    public void TakeDamage()
    {
        health--;
    }
}
