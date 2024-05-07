using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSB : MonoBehaviour
{
    StateMachine patrolState;
    StateMachine _currentState;
    void Start()
    {
        //patrolState = new StateMachine();
        _currentState= patrolState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
