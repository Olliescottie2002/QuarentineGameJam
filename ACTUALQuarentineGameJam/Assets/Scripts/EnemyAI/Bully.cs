using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bully : MonoBehaviour
{
    private EnemyFSM fsm;
    

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
            case EnemyFSM.EnemyState.Patrolling:
                fsm.Patrol();
                break;
            case EnemyFSM.EnemyState.Chasing:
                fsm.Chase();
                break;
            case EnemyFSM.EnemyState.Attacking:
                fsm.Attack();
                break;
            case EnemyFSM.EnemyState.Dead:
                fsm.Dead();
                break;
        }
    }

    

}
