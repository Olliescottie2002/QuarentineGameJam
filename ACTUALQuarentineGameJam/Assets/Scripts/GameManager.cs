using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void onStartClicked(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
    
    public void onQuitClicked()
    {
        Application.Quit();
    }
}
