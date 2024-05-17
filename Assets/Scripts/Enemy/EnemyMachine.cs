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
    private GameObject _player;
    private Animator _anim;

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
    public float chaseRange = 10;

    [Header("DistanceAttack")]
    public GameObject bullet;
    public Transform bulletpos;
    public float shootcooldawn = 2;
    public float attackrange = 6;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _anim = GetComponent<Animator>();

        _patrol = GetComponent<Patrol>();
        _chaseplayer = GetComponent<ChasePlayer>();
        _distanceattack = GetComponent<DistanceAttack>();
        _patrol.speed = patrolspeed;
        ExecuteState();

    }


    private void Update()
    {
        CheckTransition();
        ExecuteState();
    }
    
    private void ExecuteState()
    {
        switch (_currentEnemyState)
        {
            case EnemyStates.PATROL:
                //Debug.Log("Patrulla");
                _anim.SetBool("Walk",true);
                _patrol.Patrolfunc( layerFloor, layerobstacle, contrfloor, controbstacle, _rb);
                break;
            case EnemyStates.CHASE:
                //Debug.Log("Chasea");
                _anim.SetBool("Walk",true);
                _chaseplayer.Chaseplayers(chasespeed, _player, _rb);
                break;
            case EnemyStates.DISTANCEATTACK:
                //Debug.Log("Attackea");
                _anim.SetBool("Walk", false);
                _distanceattack.AttackDistance(bulletpos, attackrange, shootcooldawn, bullet,_anim);
                break;
        }
    }
    private void CheckTransition()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.transform.position);

        switch (_currentEnemyState)
        {
            case EnemyStates.PATROL:
                if (distanceToPlayer < chaseRange)
                {
                    ChangeEnemyState(EnemyStates.CHASE);
                }
                break;
            case EnemyStates.CHASE:
                if (distanceToPlayer < attackrange)
                {
                    ChangeEnemyState(EnemyStates.DISTANCEATTACK);
                }
                else if (distanceToPlayer > chaseRange)
                {
                    ChangeEnemyState(EnemyStates.PATROL);
                }
                break;
            case EnemyStates.DISTANCEATTACK:
                if (distanceToPlayer > attackrange)
                {
                    ChangeEnemyState(EnemyStates.CHASE);
                }
                break;
        }
    }

    private void ChangeEnemyState(EnemyStates state)
    {
        if (state == _currentEnemyState)
            return;
        ExitState();
        _currentEnemyState = state;
        ExecuteState();

    }

    private void ExitState()
    {
        switch (_currentEnemyState)
        {
            case EnemyStates.PATROL:
                //Debug.Log("ExitState Patrol");
                break;
            case EnemyStates.CHASE:
               // Debug.Log("ExitState Chase");

                _currentEnemyState = EnemyStates.PATROL;
                break;
            case EnemyStates.DISTANCEATTACK:
               // Debug.Log("ExitState Attack");

                 _currentEnemyState = EnemyStates.CHASE;
                break;
        }
    }
    
}
