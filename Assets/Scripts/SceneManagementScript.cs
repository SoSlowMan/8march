using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour
{
    public void BackToMenu()
    {
        //StartCoroutine(LoadMain());
        SceneManager.LoadScene("MainMenu");
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("FUCK");
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene("level2");
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene("level3");
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }

    public void DeleteSaves()
    {
        PlayerPrefs.DeleteAll();
    }
}
