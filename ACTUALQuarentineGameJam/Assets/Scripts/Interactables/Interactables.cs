using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform; // This is so that for example for a treasure chest, i can only interact with it from the front
                                           // So i create a child at the front of the chest and drag that transform in here
    private Transform player;

    bool hasInteracted;

    public GameObject[] enemiesToKill;
    private bool allEnemiesKilled = true;

    private void Start()
    {
        player = Player_Scripts.instance.transform;
    }

    private void Update()
    {
        if (!hasInteracted)
        {
            float distance = Vector2.Distance(player.position, interactionTransform.position);

            if (distance <= radius)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    for (int i = 0; i < enemiesToKill.Length; i++)
                    {
                        if(enemiesToKill[i] != null)
                        {
                            allEnemiesKilled = false;
                        }
                    }
                    if (allEnemiesKilled)
                    {
                        Interact();
                        hasInteracted = true;
                    }

                    allEnemiesKilled = true;
                }

            }
        }
    }

    private void Interact()
    {
        //Add it so that items collected ++ on game manager or something
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<Collectables>().collected += 1;
        gameObject.SetActive(false);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
