using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnerScript : MonoBehaviour
{
    [SerializeField]
    GameObject pickup, pos1, pos2;
    [SerializeField]
    float seconds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPickup1()
    {
        Instantiate(pickup, transform.position, transform.rotation);
    }

    public void SpawnPickup2()
    {
        Instantiate(pickup, pos1.transform.position, pos1.transform.rotation);
    }

    public void SpawnPickup3()
    {
        Instantiate(pickup, pos2.transform.position, pos2.transform.rotation);
    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 1; i < 5; i++)
        {
            yield return new WaitForSeconds(seconds);
            SpawnPickup1();
            seconds = Random.Range(.5f, 1f);
            yield return new WaitForSeconds(seconds);
            SpawnPickup2();
            seconds = Random.Range(.5f, 1f);
            yield return new WaitForSeconds(seconds);
            SpawnPickup3();
            i = 1;
        }
        
    }

    public void OnTriggerEnter2D()
    {

    }
}
