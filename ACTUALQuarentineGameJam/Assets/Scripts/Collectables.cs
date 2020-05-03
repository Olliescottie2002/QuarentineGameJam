using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectables : MonoBehaviour
{
    public int collected;
    public int maxCollectable;
    public GameObject winText;
    private bool won;

    private void Update()
    {
        if(collected >= maxCollectable)
        {
            //you win
            if (!won)
            {
                Invoke("LoadMenu", 4f);
                winText.SetActive(true);
                won = true;
            }
        }
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
