using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public bool IsPaused = false;

    private void Start()
    {
        Resume();

    }

    private void Update()
    {
        //if (IsPaused)
        //    Resume();
        //else
        //    Pause();

    }


    public GameObject PauseMenuCanvas;
    public void Pause()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void Resume()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
