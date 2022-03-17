using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcherScript : MonoBehaviour
{
    public GameObject player;
    public float playerRange = 4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < playerRange && Input.GetKeyDown(KeyCode.E))
        {
            if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                SceneManager.LoadScene("level2");
            }
            else
            {
                SceneManager.LoadScene("level4");
            }
        }
    }
}
