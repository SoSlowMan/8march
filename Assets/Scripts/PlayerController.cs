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
        StartCoroutine(Wait());
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

    IEnumerator Wait()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        switch (SceneManager.GetActiveScene().name)
        {
            case ("SampleScene"):
                yield return new WaitForSeconds(3f);
                break;
            case ("level3"):
                yield return new WaitForSeconds(1.8f);
                break;
        }
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
