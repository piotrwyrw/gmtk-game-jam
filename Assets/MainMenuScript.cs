using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenuScript : MonoBehaviour
{

    private int index = 1;

    public TextMeshProUGUI textMeshProUGUI;

    public void PressPlay() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }

    public void PressQuit() { 
        Application.Quit();
    }

    public void setIndexLevel1() { 
        index = 1;
        textMeshProUGUI.text = "Level 1";
    }

    public void setIndexLevel3() { 
        index = 3;
        textMeshProUGUI.text = "Level 3";
    }

    public void setIndexLevel2() { 
        index = 2;
        textMeshProUGUI.text = "Level 2";
    }

    public void serIndexLevel4() {
        index = 4;
        textMeshProUGUI.text = "Level 4";
    }

    public void serIndexLevel5()
    {
        index = 5;
        textMeshProUGUI.text = "Level 5";
    }

    public void serIndexLevel6()
    {
        index = 6;
        textMeshProUGUI.text = "Level 6";
    }

    public void serIndexLevel7()
    {
        index = 7;
        textMeshProUGUI.text = "Level 7";
    }

    public void serIndexLevel8()
    {
        index = 8;
        textMeshProUGUI.text = "Level 8";
    }

    public void setInfinityMode() {
        index = 9;
        textMeshProUGUI.text = "Infinity Mode";
    }
}
