using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneWaiterScript : MonoBehaviour
{
    [SerializeField]
    GameObject screen;
    [SerializeField]
    GameObject button;
    [SerializeField]
    Animator anim, anim2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        anim.enabled = false;
        if (SceneManager.GetActiveScene().name == "level5")
        {
            anim2.enabled = false;
        }
        screen.SetActive(true);
        button.SetActive(false);
        yield return new WaitForSeconds(3f);
        screen.SetActive(false);
        anim.enabled = true;
        if (SceneManager.GetActiveScene().name == "level5")
        {
            anim2.enabled = true;
        }
        switch (SceneManager.GetActiveScene().name)
        {
            case ("level2_2"):
                yield return new WaitForSeconds(4f);
                break;
            case ("level5"):
                yield return new WaitForSeconds(16f);
                break;
        }
        button.SetActive(true);
    }
}
