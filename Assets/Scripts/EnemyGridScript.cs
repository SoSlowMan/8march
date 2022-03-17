using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGridScript : MonoBehaviour
{
    public GameObject[] enemies;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    IEnumerator Spawn()
    {
        for (i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(true);
            yield return new WaitForSeconds(0.1f);
        } 
    }
}
