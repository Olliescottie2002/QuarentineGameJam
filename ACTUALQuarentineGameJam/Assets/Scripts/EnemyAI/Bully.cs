using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bully : MonoBehaviour
{
    private EnemyFSM fsm;
    private bool attackedThisTime;

    private void Start()
    {
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
                    MeleeAttack();
                    attackedThisTime = true;
                }
                break;
            case EnemyFSM.EnemyState.Dead:
                fsm.Dead();
                break;
        }
    }

    private void MeleeAttack()
    {

    }

}
