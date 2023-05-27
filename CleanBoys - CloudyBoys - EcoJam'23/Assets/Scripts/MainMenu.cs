using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject MenuCanvas;
    public GameObject LevelsCanvas;
    public GameObject CreditsCanvas;
    public GameObject InstructionsCanvas;


    public GameObject MusicButton;
    public GameObject NoMusicButton;
    public GameObject BGMusic;

    public bool MusicEnabled = true;

    public GameObject doNotDestroy;


    private void Awake()
    {
        //PlayerPrefs.SetInt("Audio", 1);
    }

    void Start()
    {

        //MenuCanvas = GameObject.FindGameObjectWithTag("Menu");
        //LevelsCanvas = GameObject.FindGameObjectWithTag("Level");
        //CreditsCanvas = GameObject.FindGameObjectWithTag("Credits");
        //NoMusicButton = GameObject.FindGameObjectWithTag("NoMusic");
        //MusicButton = GameObject.FindGameObjectWithTag("Music");


        MenuCanvas.SetActive(true);
        LevelsCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);

        if (PlayerPrefs.GetInt("Audio") == 0)
        {
            NoMusicButton.SetActive(true);
            MusicButton.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Audio") == 1)
        {
            MusicButton.SetActive(true);
            NoMusicButton.SetActive(false);
        }

        BGMusic = GameObject.FindGameObjectWithTag("BGMusic");
    }


    // Update is called once per frame
    void Update()
    {
       
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        MenuCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
        LevelsCanvas.SetActive(false);
        InstructionsCanvas.SetActive(true);
    }
    

    public void Levels()
    {
        MenuCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
        LevelsCanvas.SetActive(true);
        InstructionsCanvas.SetActive(false);

    }



    public void Level1()
    {
        SceneManager.LoadScene("Level01");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level02");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level03");
    }



    public void Credits()
    {
        MenuCanvas.SetActive(false);
        LevelsCanvas.SetActive(false);
        CreditsCanvas.SetActive(true);
        InstructionsCanvas.SetActive(false);

    }

    public void MenuEnabled()
    {
        LevelsCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
        InstructionsCanvas.SetActive(false);

    }


    public void NoMusic()
    {
        NoMusicButton.SetActive(false);
        MusicButton.SetActive(true);

        //BGMusic.SetActive(false);


        BGMusic.GetComponent<AudioSource>().mute = false;
        MusicEnabled = true;
        PlayerPrefs.SetInt("Audio", 1);
    }

    public void Music()
    {
        MusicButton.SetActive(false);
        NoMusicButton.SetActive(true);

        BGMusic.GetComponent<AudioSource>().mute = true;
        MusicEnabled = false;
        PlayerPrefs.SetInt("Audio", 0);

    }


}
