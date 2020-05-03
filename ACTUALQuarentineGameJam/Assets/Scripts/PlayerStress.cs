using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStress : MonoBehaviour
{
    [Header("Stress Levels")]
    public Slider stressSlider;
    private float stress = 0;

    public int timeBeforeOutOfCombat;
    private float currentTimeInCombat;
    private float currentTimeOutOfCombat;
    private bool inCombat;

    public float camShakeAmt;
    public float camShakeDuration;

    public GameObject loseText;

    [Header("Sound")]
    private AudioSource aSource;
    public AudioClip playerHit;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
        stressSlider.value = stress;
        inCombat = false;
    }
    private void Update()
    {
        stressSlider.value = stress;

        if (!CheckIfInCombat())
        {
            //If not in combat, slowly reduce stress levels
            currentTimeOutOfCombat += Time.deltaTime;
            if(stress < 0)
            {
                stress = 0;
            }
            if(stress != 0)
            {
                stress -= currentTimeOutOfCombat * 0.125f;
            }
        }        
    }

    public void TakeDamage(int damage)
    {
        aSource.PlayOneShot(playerHit);

        stress += damage;
        inCombat = true;
        currentTimeInCombat = timeBeforeOutOfCombat;
        Camera.main.GetComponent<CameraShake>().Shake(camShakeAmt, camShakeDuration);

        if (stress >= 100)
        {
            loseText.SetActive(true);
            Invoke("LoadMenu", 4f);
        }

    }

    //Make stress decrese over time

    private bool CheckIfInCombat()
    {
        if (currentTimeInCombat <= 0)
        {
            inCombat = false;
            return false;
        }
        else
        {
            currentTimeInCombat -= Time.deltaTime;
            currentTimeOutOfCombat = 0;
            inCombat = true;
            return true;
        }
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }


}
