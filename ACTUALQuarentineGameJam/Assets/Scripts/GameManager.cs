using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  void onStartClicked()
    {
        SceneManager.LoadScene("Main_Scene");
    }
}
