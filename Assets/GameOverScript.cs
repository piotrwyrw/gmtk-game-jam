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
}
