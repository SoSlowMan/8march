using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//FOR THE COLORCHANGE

public class MainMenuScript : MonoBehaviour
{
    //public Text font, font2, font3, font4, font5;
    [SerializeField]
    Text[] fonts, buttonFonts;
    [SerializeField]
    GameObject particles;
    public Camera cam;
    public GameObject changeSkinButton;
    public static MainMenuScript instance;
    public int isComplete, skin;
    [SerializeField]
    GameObject creditsScreen;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isComplete = PlayerPrefs.GetInt("Complete");
        skin = PlayerPrefs.GetInt("MMSkin");
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
        PlayerPrefs.SetInt("MMSkin", 1);
        AudioController.instance.mainMenuMusic.Stop();
        AudioController.instance.PlayKsuMusic();
        cam.backgroundColor = Color.white;
        particles.SetActive(true);
        foreach (Text font in fonts)
        {
            //font.color = new Color32(250, 180, 180, 255);
            font.color = new Color32(255, 220, 220, 255);
            font.GetComponent<Outline>().enabled = true;
        }
    }

    public void BlackSkin()
    {
        PlayerPrefs.SetInt("MMSkin", 0);
        cam.backgroundColor = new Color32(74, 74, 74, 255);
        particles.SetActive(false);
        foreach (Text font in fonts)
        {
            font.color = Color.white;
            font.GetComponent<Outline>().enabled = false;
        }
        foreach (Text font in buttonFonts)
        {
            font.color = new Color32(74, 74, 74, 255);
        }
        AudioController.instance.ksuMusic.Stop();
        AudioController.instance.PlayMainMenuMusic();
    }

    public void TurnOnCredits()
    {
        creditsScreen.SetActive(true);
    }

    public void TurnOffCredits()
    {
        creditsScreen.SetActive(false);
    }
}
