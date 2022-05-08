using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnerScript : MonoBehaviour
{
    [SerializeField]
    GameObject roadBlock;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(roadBlock, new Vector3(transform.position.x, transform.position.y + 15.41f, transform.position.z), Quaternion.identity);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + 15.41f, transform.position.z);
    }
}
