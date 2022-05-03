using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnerScript : MonoBehaviour
{
    [SerializeField]
    GameObject roadBlock;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(roadBlock);
    }
}
