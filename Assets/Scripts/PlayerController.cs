using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    private Vector2 moveInput;
    public int moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            AudioController.instance.PlayMyRoomMusic();
        }
        else
        {
            AudioController.instance.PlayKsuMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVertical = transform.right * Input.GetAxis("Horizontal");
        rb.velocity = (moveVertical) * moveSpeed;// * Time.deltaTime; doesn't work on some PC's, idk why
    }
}
