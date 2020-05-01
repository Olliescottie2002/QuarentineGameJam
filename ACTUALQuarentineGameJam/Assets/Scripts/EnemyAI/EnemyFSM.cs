using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    private Transform player;
    public int health;

    public enum EnemyState
    {
        Idle,
        Patrolling,
        Chasing,
        Attacking,
        Dead
    }

    public EnemyState currentState;

    [Header("Idle")]
    public int minTimeBtwIdle;
    public int maxTimeBtwIdle;

    private bool setIdleTime;
    private float currentTimeBtwIdle;

    [Header("Patrol")]
    public float patrolSpeed;

    [Header("Chase")]
    public float aggroRadius;
    public float unAggroRadius;
    public float chaseSpeed;

    [Header("Attack")]
    public float attackRange;


    private void Start()
    {
        player = Player_Scripts.instance.transform;
        currentState = EnemyState.Idle;
    }

    private void Update()
    {
        player = Player_Scripts.instance.transform;
    }

    public void Idle()
    {
        print("Idleing");
        if(Vector2.Distance(transform.position, player.position) <= aggroRadius)
        {
            //Go to chase state
            setIdleTime = false;
            currentState = EnemyState.Chasing;
        }
        else
        {
            if (setIdleTime)
            {
                if(currentTimeBtwIdle <= 0)
                {
                    //Go to Patrol State
                    setIdleTime = false;
                    currentState = EnemyState.Patrolling;
                
                }
                else
                {
                    currentTimeBtwIdle -= Time.deltaTime;
                }
            }
            else
            {
                currentTimeBtwIdle = UnityEngine.Random.Range(minTimeBtwIdle, maxTimeBtwIdle + 1);
                setIdleTime = true;
            }
        }

    }

    public void Patrol()
    {
        print("Patrolling");
        //Could potentially make it so that you can set waypoints for these enemies to follow

        if (Vector2.Distance(transform.position, player.position) <= aggroRadius)
        {
            //Go to chase state
            currentState = EnemyState.Chasing;
        }
    }
    public void Chase()
    {
        print("Chasing");
        if(Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            currentState = EnemyState.Attacking;
        }
        else
        {
            if(Vector2.Distance(transform.position, player.position) >= unAggroRadius)
            {
                //Stop chasing
                currentState = EnemyState.Idle;
            }
            else
            {
                if(transform.position.x > player.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }

                transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
            }
        }


    }
    public void Attack()
    {
        print("Attacking");
        //here we would run some code to do with attacking the player but also maybe a coroutine b4 returning to chasing
        Invoke("ReturnBackToChasing", 1);
        
    }
    public void Dead()
    {
        print("Dead");
    }

    private void ReturnBackToChasing()
    {
        currentState = EnemyState.Chasing;
    }

    public void TakeDamageFromProjectile()
    {
        health -= 1;

        if (health <= 0)
        {
            currentState = EnemyState.Dead;
            Destroy(gameObject);
        }
    }
}
