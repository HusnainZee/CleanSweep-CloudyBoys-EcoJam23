using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoNotDestroy : MonoBehaviour
{

    public GameObject doNotDestroy;

    //private GameObject MenuCanvas;

    //private void Update()
    //{
    //    if (SceneManager.GetActiveScene().name == "Menu")
    //    {
    //        TempInput = GameObject.FindGameObjectWithTag("Name");
    //        Inputt = TempInput.GetComponent<InputField>();
    //    }

    //}


    private static DoNotDestroy instance = null;

    public static DoNotDestroy Instance
    {
        get { return instance; }
    }



    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("Destroyed");
            Destroy(doNotDestroy);
        }
        else
        {
            Debug.Log("INstance = thisS");

            instance = this;
        }

        DontDestroyOnLoad(doNotDestroy);
    }



}
