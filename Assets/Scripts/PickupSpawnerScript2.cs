using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnerScript2 : MonoBehaviour
{
    public GameObject pickup;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPickup()
    {
        Instantiate(pickup, transform.position, transform.rotation);
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < 100; i++)
        {
            SpawnPickup();
            yield return new WaitForSeconds(7f);
        }
    }
}
