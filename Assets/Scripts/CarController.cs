using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public static CarController instance;
    public Rigidbody2D rb;
    private Vector2 moveInput;
    public int moveSpeed;
    public int counter;
    [SerializeField]
    private Animator anim;
    private Quaternion leftTurn, rightTurn, zeroTurn, leftShipTurn, rightShipTurn;
    [SerializeField]
    GameObject image;
    [SerializeField]
    float timeCount = 0.0f;//для поворота
    float turnSpeed = 2f;
    [SerializeField]
    GameObject mainCamera;
    [SerializeField]
    GameObject spawner;
    [SerializeField]
    GameObject borders;
    public bool done;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    GameObject bullet;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        done = false;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        spawner = GameObject.FindGameObjectWithTag("PickupSpawner");
        borders = GameObject.FindGameObjectWithTag("Borders");
        leftTurn = Quaternion.Euler(new Vector3(0f, 0f, 15f));
        leftShipTurn = Quaternion.Euler(new Vector3(0f, 15f, 0f));
        rightShipTurn = Quaternion.Euler(new Vector3(0f, 15f, 0f));
        rightTurn = Quaternion.Euler(new Vector3(0f, 0f, -15f));
        zeroTurn = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        //StartCoroutine(Wait());
        counter = 0;
        AudioController.instance.PlayRoadMusic();
        AudioController.instance.PlayEngineSound();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraFollow();
        SpawnerFollow();
        BordersFollow();
        LevelSwitcher();

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            AudioController.instance.PlayShootSound();
        }
    }

    IEnumerator Wait()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(2f);
        image.transform.rotation = zeroTurn;
        rb.constraints = RigidbodyConstraints2D.None;
        //rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Move()
    {
        Vector3 moveVertical = transform.up;
        Vector3 moveHorizontal = transform.right * Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") > 0)
        {
            TurnRight();
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            TurnLeft();
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            ZeroTurn();
        }
        rb.velocity = (moveHorizontal + moveVertical) * moveSpeed;

        if (moveHorizontal == new Vector3(0f,0f,0f))
            timeCount = 0;
    }

    void TurnRight()
    {
        if (SceneManager.GetActiveScene().name == "level6")
        {
            image.transform.rotation = Quaternion.Slerp(image.transform.rotation, rightShipTurn, turnSpeed * timeCount);
        }
        else
        {
            image.transform.rotation = Quaternion.Slerp(image.transform.rotation, rightTurn, turnSpeed * timeCount);
        }
        timeCount = timeCount + Time.deltaTime;
    }

    void TurnLeft()
    {
        if (SceneManager.GetActiveScene().name == "level6")
        {
            image.transform.rotation = Quaternion.Slerp(image.transform.rotation, leftShipTurn, turnSpeed * timeCount);
        }
        else
        {
            image.transform.rotation = Quaternion.Slerp(image.transform.rotation, leftTurn, turnSpeed * timeCount);
        }
        timeCount = timeCount + Time.deltaTime;
    }

    void ZeroTurn()
    {
        image.transform.rotation = Quaternion.Slerp(image.transform.rotation, zeroTurn, turnSpeed * 0.1f);
    }

    void CameraFollow()
    {
        Vector3 carPos = new Vector3(0f, transform.position.y + 3.15f, -10f);
        mainCamera.transform.position = carPos;
    }

    void SpawnerFollow()
    {
        Vector3 carPos = new Vector3(0f, transform.position.y + 15f, 0f);
        spawner.transform.position = carPos;
    }

    void BordersFollow()
    {
        Vector3 carPos = new Vector3(0f, transform.position.y, 0f);
        borders.transform.position = carPos;
    }

    void LevelSwitcher()
    {
        if (SceneManager.GetActiveScene().name == "level2")
        {
            if (counter == 12)
            {
                SceneManager.LoadScene("level2_2");
                done = true;
            }
        }
        else if (counter == 17)
        {
            SceneManager.LoadScene("level5");
            done = true;
        }
    }
}
