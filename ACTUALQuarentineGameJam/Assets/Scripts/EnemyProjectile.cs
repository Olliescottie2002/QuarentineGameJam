using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Vector3 target;
    public float projectileSpeed;

    private void Start()
    {
        Invoke("DestroySelf", 5);

        //Turns the projectile to face towards the target
        Vector3 direction = target - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (target.x >= transform.position.x)
        {
            if (target.y >= transform.position.y)
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
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStress>().TakeDamage(5);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
