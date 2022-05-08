using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
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
