using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0,sprites.Length)];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioController.instance.PlayPickupSound();
            CarController.instance.counter++;
            Destroy(gameObject);
        }
        else if (other.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
