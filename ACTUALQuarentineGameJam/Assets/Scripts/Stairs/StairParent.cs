using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairParent : MonoBehaviour
{
    public bool justTeleported;
    public float timeBtwTeleport;
    public float timeCap;

    private void Update()
    {
        timeBtwTeleport += Time.deltaTime;
    }
}
