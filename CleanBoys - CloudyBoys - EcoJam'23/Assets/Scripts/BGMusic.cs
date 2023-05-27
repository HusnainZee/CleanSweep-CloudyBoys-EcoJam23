using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{

    public GameObject doNotDestroy;
    private static BGMusic instance = null;

    public static BGMusic Instance
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
