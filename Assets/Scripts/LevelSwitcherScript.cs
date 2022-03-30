using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcherScript : MonoBehaviour
{
    public GameObject player;
    public float playerRange = 4f;
    public GameObject buttonPromt;
    bool touched;

    // Start is called before the first frame update
    void Start()
    {
        buttonPromt.SetActive(false);
        touched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < playerRange)
        {
            touched = true;
            if (Input.GetKeyDown(KeyCode.E))
            {    
                switch (SceneManager.GetActiveScene().name)
                {
                    case "SampleScene":
                        SceneManager.LoadScene("level2");
                        break;
                    case "level3":
                        SceneManager.LoadScene("level4");
                        break;
                }
            }
        }

        if (touched == true)
        {
            buttonPromt.SetActive(true);
        }
    }
}
