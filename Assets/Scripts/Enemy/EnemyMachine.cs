using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMachine : MonoBehaviour
{
    private enum EnemyStates
    {
       PATROL,
       CHASE,
       DISTANCEATTACK
    }

    private EnemyStates state = EnemyStates.PATROL;
    ChasePlayer _chaseplayer;
    Patrol _patrol;
    EnemyFSB _enemyFSB;

    private void ChangeGameState(EnemyStates state)
    {

    }

    private void ExitCurrentState()
    {

    }
    private void EnterCurrentState()
    {

    }
}
