using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    public static ShipController instance;
    public GameObject bullet;
    public Rigidbody2D rb;
    private Vector2 moveInput;
    public int moveSpeed;
    public Transform firePoint, firePoint1;
    public Animator anim;
    public int counter;
    //public GameObject endText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        AudioController.instance.PlayShootMusic();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVertical = transform.right * Input.GetAxis("Horizontal");
        rb.velocity = (moveVertical) * moveSpeed;// * Time.deltaTime; doesn't work on some PC's, idk why

        if (transform.position.y == -4f)
        {
            anim.enabled = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                Instantiate(bullet, firePoint1.position, firePoint1.rotation);
                AudioController.instance.PlayShootSound();
        }

        if (counter == 22)
        {
            PlayerPrefs.SetInt("Complete", 1);
            //endText.SetActive(true);
            SceneManager.LoadScene("level7");
            //Destroy(gameObject);
        }
    }
}
