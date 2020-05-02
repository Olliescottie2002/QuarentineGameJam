using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public Vector3 target;
    public float projectileSpeed;
    public GameObject penDestroy;

    private void Start()
    {
        Invoke("DestroySelf", 5);

        //Turns the projectile to face towards the target
        Vector3 direction = target - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(target.x >= transform.position.x)
        {
            if(target.y >= transform.position.y)
            {
                angle = 90 - angle;
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -angle);
            }
            else
            {
                angle = angle - 90;
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
            }
        }
        else
        {
            if (target.y >= transform.position.y)
            {
                angle = angle - 90;
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
            }
            else
            {
                angle = 90 + (180 + angle);
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
            }
        }        
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bully"))
        {
            other.GetComponent<EnemyFSM>().TakeDamageFromProjectile();
            Instantiate(penDestroy, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Environment"))
        {
            Instantiate(penDestroy, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
