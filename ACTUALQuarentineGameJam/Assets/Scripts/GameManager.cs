using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioClip buttonPress;
    private AudioSource ad;


    public string tutorialSscene;


    private void Start()
    {
        ad = GetComponent<AudioSource>();
    }
    public void onStartClicked(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
        ad.PlayOneShot(buttonPress);
    }
    
    public void OnTutorialClicked()
    {
        SceneManager.LoadScene(tutorialSscene);
        ad.PlayOneShot(buttonPress);
    }

    public void onQuitClicked()
    {
        print("Quitting Game");
        ad.PlayOneShot(buttonPress);
        Application.Quit();
    }
}
