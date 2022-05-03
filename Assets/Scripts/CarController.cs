using System.Collections;
using System.Collections.Generic;
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

    private States State //свойство типа States
    {
        get { return (States)anim.GetInteger("state"); } //получаем значение state из аниматора
        set { anim.SetInteger("state", (int)value); } //меняем значение state
    }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
        counter = 0;
        AudioController.instance.PlayRoadMusic();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVertical = transform.right * Input.GetAxis("Horizontal");
        rb.velocity = (moveVertical) * moveSpeed;
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

    public enum States
    {
        left,
        right
    }
}
