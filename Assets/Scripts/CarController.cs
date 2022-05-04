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
    private Quaternion leftTurn, rightTurn;
    [SerializeField]
    GameObject image;
    [SerializeField]
    float timeCount = 0.0f;//для поворота
    float turnSpeed = 0.2f;

    /*private States State //свойство типа States
    {
        get { return (States)anim.GetInteger("state"); } //получаем значение state из аниматора
        set { anim.SetInteger("state", (int)value); } //меняем значение state
    }*/

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        leftTurn = Quaternion.Euler(new Vector3(0f, 0f, 15f));
        rightTurn = Quaternion.Euler(new Vector3(0f, 0f, 15f));
        StartCoroutine(Wait());
        counter = 0;
        AudioController.instance.PlayRoadMusic();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (SceneManager.GetActiveScene().name == "level2")
        {
            if (counter == 7)
            {
                SceneManager.LoadScene("level2_2");
            }
        }
        else if (counter == 12)
        {
            SceneManager.LoadScene("level5");
        }
        
    }

    IEnumerator Wait()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(2f);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    /*public enum States
    {
        left,
        right
    }*/

    void Move()
    {
        Vector3 moveVertical = transform.right * Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") > 0)
        {
            image.transform.rotation = Quaternion.Slerp(transform.rotation, rightTurn, timeCount);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            image.transform.rotation = Quaternion.Slerp(transform.rotation, leftTurn, timeCount);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            timeCount = 0;
        }
        timeCount += Time.deltaTime * turnSpeed;
        rb.velocity = (moveVertical) * moveSpeed;
    }
}
