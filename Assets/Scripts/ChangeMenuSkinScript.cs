using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMenuSkinScript : MonoBehaviour
{
    public void ChangeSkin()
    {
        if (PlayerPrefs.GetInt("MMSkin") == 1)
        {
            MainMenuScript.instance.WhiteSkin();
        }
        else
        {
            MainMenuScript.instance.BlackSkin();
        }
    }
}
