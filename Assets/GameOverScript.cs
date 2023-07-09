using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
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

        if (SceneManager.GetActiveScene().buildIndex == 7) {
            SceneManager.LoadScene(1);
        }
        else{ 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void QuitLevel() {
        SceneManager.LoadScene(0);
    }
    }
