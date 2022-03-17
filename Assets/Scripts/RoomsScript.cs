using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsScript : MonoBehaviour
{
    public GameObject gameCamera;
    Vector3 cameraPos;
    public bool isTriggered;

    // Start is called before the first frame update
    void Start()
    {
        //isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTriggered)
        {
            if (other.tag == "Player")
            {
                isTriggered = true;
                cameraPos = gameCamera.transform.position;
                cameraPos.x = 17.8f;
                gameCamera.transform.position = cameraPos;
            }
        }
        else if (other.tag == "Player")
        {
            isTriggered = false;
            cameraPos = gameCamera.transform.position;
            cameraPos.x = 0f;
            gameCamera.transform.position = cameraPos;
        }

    }
}
