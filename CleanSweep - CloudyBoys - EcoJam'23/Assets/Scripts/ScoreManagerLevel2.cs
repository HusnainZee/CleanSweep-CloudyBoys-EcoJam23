using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManagerLevel2 : MonoBehaviour
{

    public TextMeshProUGUI CorrectTextUI;
    public TextMeshProUGUI WrongTextUI;

    public int Correct = 0;
    public int Wrong = 0;

    public int TotalCollectedGarbage = 0;


    public GameObject WinCanvas;
    public GameObject LossCanvas;


    public AudioSource WinSound;
    public AudioSource LossSound;

    private bool IsGameEnd = false;

    public GameObject allTrash;

    // TIMER

    public float totalTime = 60f;
    private float currentTime;
    private bool isCountingDown = false;
    public TextMeshProUGUI timerText;

    public GameObject timeDecreasePrefab;
    public Transform timeDecreasePrefabPos;

    public GameObject timeIncreasePrefab;

    private void Start()
    {

        allTrash.SetActive(true);

        Correct = 0;
        Wrong = 0;

        CorrectTextUI.text = "" + 0;
        WrongTextUI.text = "" + 0;

        WinCanvas.SetActive(false);
        LossCanvas.SetActive(false);

        TotalCollectedGarbage = 0;
        IsGameEnd = false;
        PlayerPrefs.SetInt("Level", 2);

        ResetTimer();
        StartTimer();

    }

    public void StartTimer()
    {
        isCountingDown = true;
    }

    public void StopTimer()
    {
        isCountingDown = false;
    }

    private void UpdateTimerText()
    {
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        if (seconds < 0)
            seconds = 0;
        timerText.text = seconds.ToString();
    }

    public void ResetTimer()
    {
        currentTime = totalTime;
        UpdateTimerText();
    }

    private void CountdownFinished()
    {
        StopTimer();
    }
    public void ApplyBonus()
    {

        Instantiate(timeIncreasePrefab, timeDecreasePrefabPos);
        Debug.Log("Instantiated");
        //

        float timeLeft = Mathf.Max(currentTime + 1f, 0f);

        currentTime = timeLeft;
        UpdateTimerText();
    }

    public void ApplyPenalty()
    {

        Instantiate(timeDecreasePrefab, timeDecreasePrefabPos);

        float timeLeft = Mathf.Max(currentTime - 2f, 0f);

        if (timeLeft <= 0f)
        {
            currentTime = timeLeft;
            CountdownFinished();
        }
        else
        {
            currentTime = timeLeft;
            UpdateTimerText();
        }
    }

    private void Update()
    {
        if (isCountingDown)
        {
            currentTime -= Time.deltaTime;

            UpdateTimerText();

            if (currentTime <= 0f)
            {
                CountdownFinished();

                allTrash.SetActive(false);

                if (TotalCollectedGarbage >= 24 && (Correct > Wrong) && IsGameEnd == false)
                {
                    IsGameEnd = true;

                    WinCanvas.SetActive(true);

                    if (PlayerPrefs.GetInt("Audio") == 1)
                        WinSound.Play();

                    WinCorrectScore.text = "" + Correct;
                    WinWrongScore.text = "" + Wrong;
                    Time.timeScale = 0f;

                }
                else if (TotalCollectedGarbage < 24 && IsGameEnd == false)
                {
                    IsGameEnd = true;
                    Time.timeScale = 0f;

                    LossCanvas.SetActive(true);

                    if (PlayerPrefs.GetInt("Audio") == 1)
                        LossSound.Play();

                    LossCorrectScore.text = "" + Correct;
                    LossWrongScore.text = "" + Wrong;
                    Time.timeScale = 0f;

                }
            }
        }

        if ((TotalCollectedGarbage == 24) && IsGameEnd == false)
        {
            IsGameEnd = true;
            EndLevel();
        }
    }

    public TextMeshProUGUI WinCorrectScore;
    public TextMeshProUGUI WinWrongScore;

    public TextMeshProUGUI LossCorrectScore;
    public TextMeshProUGUI LossWrongScore;

    public void EndLevel()
    {
        allTrash.SetActive(false);

        if (Correct > Wrong)
        {
            WinCanvas.SetActive(true);

            if (PlayerPrefs.GetInt("Audio") == 1)
            {
                WinSound.Play();
            }

            WinCorrectScore.text = "" + Correct;
            WinWrongScore.text = "" + Wrong;
        }
        else if (Wrong >= Correct)
        {
            LossCanvas.SetActive(true);

            if (PlayerPrefs.GetInt("Audio") == 1)
            {
                LossSound.Play();
            }

            LossCorrectScore.text = "" + Correct;
            LossWrongScore.text = "" + Wrong;
        }

        Time.timeScale = 0f;

    }


    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level03");
    }


}
