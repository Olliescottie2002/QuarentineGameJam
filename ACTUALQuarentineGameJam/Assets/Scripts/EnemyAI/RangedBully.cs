using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBully : MonoBehaviour
{
    private EnemyFSM fsm;
    private Transform player;

    public GameObject sodaCan;

    private bool attackedThisTime;

    private void Start()
    {
        player = Player_Scripts.instance.transform;
        fsm = GetComponent<EnemyFSM>();
    }

    private void FixedUpdate()
    {
        switch (fsm.currentState)
        {
            case EnemyFSM.EnemyState.Idle:
                fsm.Idle();
                break;
            case EnemyFSM.EnemyState.Chasing:
                fsm.Chase();
                attackedThisTime = false;
                break;
            case EnemyFSM.EnemyState.Attacking:
                fsm.Attack();
                if (!attackedThisTime)
                {
                    ProjectileAttack();
                    attackedThisTime = true;
                }
                break;
            case EnemyFSM.EnemyState.Dead:
                fsm.Dead();
                break;
        }
    }

    void ProjectileAttack()
    {
        GameObject objectInstantiated = Instantiate(sodaCan, transform.position, Quaternion.identity);
        objectInstantiated.GetComponent<EnemyProjectile>().target = player.position;
    }
}

