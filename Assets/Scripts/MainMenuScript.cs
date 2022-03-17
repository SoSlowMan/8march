using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//FOR THE COLORCHANGE

public class MainMenuScript : MonoBehaviour
{
    public Text font, font2;
    public Camera cam;
    public GameObject changeSkinButton;
    public static MainMenuScript instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("Complete", 1);
        if (PlayerPrefs.GetInt("Complete") == 1)
        {
            PlayerPrefs.SetInt("MMSkin", 1);
            //changeSkinButton.SetActive(true);
            WhiteSkin();
        }
        else
        {
            BlackSkin();
            //changeSkinButton.SetActive(false);
        }
    }

    public void WhiteSkin()
    {
        AudioController.instance.PlayKsuMusic();
        cam.backgroundColor = Color.white;
        font.color = new Color32(250, 180, 180, 255);
        font2.color = new Color32(250, 180, 180, 255);
    }

    public void BlackSkin()
    {
        cam.backgroundColor = new Color32(74, 74, 74, 255);
        AudioController.instance.PlayMainMenuMusic();
    }

    
}
