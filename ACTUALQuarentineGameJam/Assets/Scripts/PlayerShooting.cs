using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Vector3 target;
    public GameObject pen;

    private void Start()
    {
        target = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target += new Vector3(0, 0, 10);

            //Spawn projectile
            GameObject objectSpawned = Instantiate(pen, transform.position, Quaternion.identity);
            objectSpawned.GetComponent<PlayerProjectile>().target = target;

        }

    }
}
