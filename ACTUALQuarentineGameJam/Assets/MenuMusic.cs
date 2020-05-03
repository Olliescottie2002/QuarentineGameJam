using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioSource ad;

    private void Update()
    {
        if (!ad.isPlaying)
        {
            ad.Play();
        }
    }
}
