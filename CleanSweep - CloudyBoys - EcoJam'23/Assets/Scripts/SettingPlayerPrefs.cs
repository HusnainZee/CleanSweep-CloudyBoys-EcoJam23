using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPlayerPrefs : MonoBehaviour
{

    private void Awake()
    {
        PlayerPrefs.SetInt("Audio", 1);

    }

    void Start()
    {
        SceneManager.LoadScene("Menu");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
