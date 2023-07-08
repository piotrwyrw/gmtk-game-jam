using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    private int index = 1;
    public void PressPlay() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PressQuit() { 
        Application.Quit();
    }

    public void setIndexLevel1() { 
        index = 1;
    }

    public void setIndexLevel3() { 
        index = 3;
    }

    public void setIndexLevel2() { 
        index = 2;
    }
}
