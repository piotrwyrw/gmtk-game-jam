using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenuScript : MonoBehaviour
{

    public TextMeshProUGUI textMeshProUGUI;

    public void PressQuit() { 
        Application.Quit();
    }

    public void setIndexLevel1() {
        SceneManager.LoadScene("Level01");
    }

    public void setIndexLevel3() {
        SceneManager.LoadScene("Level03");
    }

    public void setIndexLevel2() {
        SceneManager.LoadScene("Level02");
    }

    public void serIndexLevel4() {
        SceneManager.LoadScene("Level04");
    }

    public void serIndexLevel5()
    {
        SceneManager.LoadScene("Level05");
    }

    public void serIndexLevel6()
    {
        SceneManager.LoadScene("Level06");
    }

    public void serIndexLevel7()
    {
        SceneManager.LoadScene("Level07");
    }

    public void setInfinityMode() {
        SceneManager.LoadScene("Infinity");
    }
}
