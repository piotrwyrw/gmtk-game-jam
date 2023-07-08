using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
}
