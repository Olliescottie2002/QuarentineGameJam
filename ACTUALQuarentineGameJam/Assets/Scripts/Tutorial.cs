using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public string ChosenLevel;

    public GameObject continueButton;

    void Start()
    {

        StartCoroutine(Type());

    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }


    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed / 10);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences[index].Length)
        {

            if (index >= sentences.Length - 1)
            {                
                SceneManager.LoadScene(ChosenLevel); 
                return;
            }

            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            SceneManager.LoadScene(ChosenLevel);
        }
    }
}
