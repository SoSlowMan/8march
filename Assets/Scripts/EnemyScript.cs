using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 1;

    [SerializeField]
    Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
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
