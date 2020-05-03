using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string tutorialSscene;

    public void onStartClicked(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
    
    public void OnTutorialClicked()
    {
        SceneManager.LoadScene(tutorialSscene);
    }

    public void onQuitClicked()
    {
        print("Quitting Game");
        Application.Quit();
    }
}
