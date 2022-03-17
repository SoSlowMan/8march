using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public float pickupSpeed = 5f;

    public Rigidbody2D theRB;

    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * pickupSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioController.instance.PlayPickupSound();
            CarController.instance.counter++;
            //other.GetComponent<EnemyScript>().TakeDamage();
            Destroy(gameObject);
        }
        else if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
