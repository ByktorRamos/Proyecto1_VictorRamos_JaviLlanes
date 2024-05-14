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
    private Rigidbody2D _rb;
    private GameObject player;


    private EnemyStates _currentEnemyState = EnemyStates.PATROL;
    ChasePlayer _chaseplayer;
    Patrol _patrol;
    DistanceAttack _distanceattack;

    [Header("Patrol")]
    public float patrolspeed;
    public LayerMask layerFloor;
    public LayerMask layerobstacle;
    public Transform contrfloor;
    public Transform controbstacle;

    [Header("Chase")]
    public float chasespeed = 2;
    public float chaseRange = 8;

    [Header("DistanceAttack")]
    public GameObject bullet;
    public Transform bulletpos;
    public float shootcooldawn = 2;
    public float detectionrange = 10;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        //_patrol = GetComponent<Patrol>();
        EnterState();
    }


    private void Update()
    {
        CheckTransition();
    }
    private void EnterState()
    {
        switch (_currentEnemyState) 
        {
            case EnemyStates.PATROL:
                _patrol.Patrolfunc(patrolspeed,layerFloor,layerobstacle,contrfloor,controbstacle,_rb);
                break;
            case EnemyStates.CHASE:
                //_chaseplayer.Chaseplayers(chasespeed,player);
                break;
            case EnemyStates.DISTANCEATTACK:
                _distanceattack.AttackDistance(bulletpos, detectionrange, shootcooldawn, bullet);
                break;
        }
    }
    private void CheckTransition()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < chaseRange)
        {
           ChangeEnemyState(EnemyStates.DISTANCEATTACK);
        }
        if (distanceToPlayer<detectionrange)
        {
            ChangeEnemyState(EnemyStates.DISTANCEATTACK);

        }
    }
    private void ChangeEnemyState(EnemyStates state)
    {
        if (state == _currentEnemyState)
            return;
        ExitState();
        _currentEnemyState = state;
        EnterState();
    }

    private void ExitState()
    {
        switch (_currentEnemyState)
        {
            case EnemyStates.PATROL:
                break;
            case EnemyStates.CHASE:
                _currentEnemyState = EnemyStates.PATROL;
                break;
            case EnemyStates.DISTANCEATTACK:
                _currentEnemyState = EnemyStates.CHASE;
                break;
        }
    }
    
}
