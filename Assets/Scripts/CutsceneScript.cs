using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "level2_2")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("level3");
            }
        }
        else if (SceneManager.GetActiveScene().name == "level5")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("level6");
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
