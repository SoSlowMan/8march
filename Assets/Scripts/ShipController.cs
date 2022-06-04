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
    public Transform firePoint;
    public int counter;
    //public GameObject endText;
    [SerializeField]
    Camera mainCamera;

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

        if (Input.GetMouseButtonDown(0))
        {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
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

    /*IEnumerator Wait()
    {
        anim.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(2f);
        rb.constraints = RigidbodyConstraints2D.None; //не работает
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        anim.enabled = true;
        yield return new WaitForSeconds(0f);
    }*/
    void CameraFollow()
    {
        Vector3 carPos = new Vector3(0f, transform.position.y + 3.15f, -10f);
        mainCamera.transform.position = carPos;
    }
}




