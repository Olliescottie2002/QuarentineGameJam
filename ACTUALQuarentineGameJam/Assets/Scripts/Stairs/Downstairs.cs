using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Downstairs : MonoBehaviour
{
    private Transform player;
    StairParent parentGO;
    BoxCollider2D otherCollider;

    private void Start()
    {
        player = Player_Scripts.instance.transform;
        parentGO = transform.parent.GetComponent<StairParent>(); //set active false and true the colliders
        otherCollider = transform.parent.GetChild(1).GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(parentGO.timeBtwTeleport > parentGO.timeCap)
        {
            if (!otherCollider.gameObject.activeInHierarchy)
            {
                otherCollider.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!transform.parent.GetComponent<StairParent>().justTeleported)
            {
                //teleport to downstairs
                parentGO.timeBtwTeleport = 0;
                parentGO.justTeleported = true;
                otherCollider.gameObject.SetActive(false);
                player.position = transform.parent.GetChild(1).transform.position;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (parentGO.timeBtwTeleport > parentGO.timeCap)
            {
                parentGO.justTeleported = false;
            }
        }
    }
}
