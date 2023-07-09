using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public GameObject nextLevel;
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.SetActive(false);
    }

    public void GoToMenue()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel() {

        if (SceneManager.GetActiveScene().buildIndex == 3) {
            SceneManager.LoadScene(1);
        }
        else{ 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    }