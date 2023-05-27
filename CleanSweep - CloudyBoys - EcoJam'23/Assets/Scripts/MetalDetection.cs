using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetection : MonoBehaviour
{
    public GameObject Tick;
    public GameObject Cross;

    public GameObject ScoreManagerr;
    private ScoreManager SC;
    private ScoreManagerLevel2 SC2;
    private ScoreManagerLevel3 SC3;

    public Animator Anim;

    public AudioSource CorrectSound;
    public AudioSource WrongSound;

    private MainMenu MM;

    private void Start()
    {
        Tick.SetActive(false);
        Cross.SetActive(false);

        if (PlayerPrefs.GetInt("Level") == 1)
            SC = ScoreManagerr.GetComponent<ScoreManager>();
        else if (PlayerPrefs.GetInt("Level") == 2)
            SC2 = ScoreManagerr.GetComponent<ScoreManagerLevel2>();
        else if (PlayerPrefs.GetInt("Level") == 3)
            SC3 = ScoreManagerr.GetComponent<ScoreManagerLevel3>();
        //MM = GameObject.FindGameObjectWithTag("Controller").GetComponent<MainMenu>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Metal")
        {
            Destroy(collision.gameObject);


            Cross.SetActive(false);
            Tick.SetActive(true);

            Debug.Log("Audio: " + PlayerPrefs.GetInt("Audio"));

            if (PlayerPrefs.GetInt("Audio") == 1)
                CorrectSound.Play();

            Debug.Log("Level: " + PlayerPrefs.GetInt("Level"));

            if (PlayerPrefs.GetInt("Level") == 1)
            {
                SC.Correct += 1;
                SC.CorrectTextUI.text = "" + SC.Correct;
                SC.TotalCollectedGarbage += 1;
                SC.ApplyBonus();
            }
            else if (PlayerPrefs.GetInt("Level") == 2)
            {
                SC2.Correct += 1;
                SC2.CorrectTextUI.text = "" + SC2.Correct;
                SC2.TotalCollectedGarbage += 1;
                SC2.ApplyBonus();
            }
            else if (PlayerPrefs.GetInt("Level") == 3)
            {
                SC3.Correct += 1;
                SC3.CorrectTextUI.text = "" + SC3.Correct;
                SC3.TotalCollectedGarbage += 1;
                SC3.ApplyBonus();
            }
            else
            {

            }

            
            Anim.SetBool("MetalWrong", false);
            Anim.SetBool("MetalCorrect", true);

            StartCoroutine(Wait());
        }
        else if (collision.tag == "Glass" || collision.tag == "Plastic" || collision.tag == "Organic" || collision.tag == "Paper")
        {
            Destroy(collision.gameObject);

            Tick.SetActive(false);
            Cross.SetActive(true);

            Debug.Log("Audio: " + PlayerPrefs.GetInt("Audio"));

            if (PlayerPrefs.GetInt("Audio") == 1)
                WrongSound.Play();

            if (PlayerPrefs.GetInt("Level") == 1)
            {
                SC.Wrong += 1;
                SC.WrongTextUI.text = "" + SC.Wrong;
                SC.TotalCollectedGarbage += 1;

                SC.ApplyPenalty();

            }
            else if (PlayerPrefs.GetInt("Level") == 2)
            {
                SC2.Wrong += 1;
                SC2.WrongTextUI.text = "" + SC2.Wrong;
                SC2.TotalCollectedGarbage += 1;

                SC2.ApplyPenalty();

            }
            else if (PlayerPrefs.GetInt("Level") == 3)
            {
                SC3.Wrong += 1;
                SC3.WrongTextUI.text = "" + SC3.Wrong;
                SC3.TotalCollectedGarbage += 1;

                SC3.ApplyPenalty();

            }
            else
            {

            }

            Anim.SetBool("MetalCorrect", false);
            Anim.SetBool("MetalWrong", true);

            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);

        Tick.SetActive(false);
        Cross.SetActive(false);

        Anim.SetBool("MetalWrong", false);
        Anim.SetBool("MetalCorrect", false);
    }
}
