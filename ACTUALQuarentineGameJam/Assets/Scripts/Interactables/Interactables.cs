using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform; // This is so that for example for a treasure chest, i can only interact with it from the front
                                           // So i create a child at the front of the chest and drag that transform in here
    public Transform player;

    bool hasInteracted;

    private void Update()
    {
        if (!hasInteracted)
        {
            float distance = Vector2.Distance(player.position, interactionTransform.position);

            if (distance <= radius)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Interact();
                    hasInteracted = true;
                }

            }
        }
    }

    private void Interact()
    {
        print("Interacted");
        gameObject.SetActive(false);
    }


    private void OnDrawGizmosSelected()
    {


        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
