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
        SceneManager.LoadScene(1);
    }

    public void setIndexLevel3() {
        SceneManager.LoadScene(3);
    }

    public void setIndexLevel2() {
        SceneManager.LoadScene(2);
    }

    public void serIndexLevel4() {
        SceneManager.LoadScene(4);
    }

    public void serIndexLevel5()
    {
        SceneManager.LoadScene(5);
    }

    public void serIndexLevel6()
    {
        SceneManager.LoadScene(6);
    }

    public void serIndexLevel7()
    {
        SceneManager.LoadScene(7);
    }

    public void setInfinityMode() {
        SceneManager.LoadScene(8);
    }
}
