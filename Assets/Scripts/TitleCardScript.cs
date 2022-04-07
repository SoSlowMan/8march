using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCardScript : MonoBehaviour
{
    [SerializeField]
    GameObject screen;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TitleScreen());
    }

    IEnumerator TitleScreen()
    {
        screen.SetActive(true);
        switch (SceneManager.GetActiveScene().name)
        {
            case("SampleScene"):
                yield return new WaitForSeconds(3f);
                break;
            case ("level3"):
                yield return new WaitForSeconds(2.3f);
                break;
            case ("level6"):
                yield return new WaitForSeconds(2f);
                break;
        }
        screen.SetActive(false);
    }
}
