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
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            CarController.instance.counter++;
            AudioController.instance.PlayExplosionSound();
            Destroy(gameObject);
        }        
    }

    public void TakeDamage()
    {
        health--;
    }
}
