using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaEstadoEnum : MonoBehaviour
{

    private enum Estados
    {
        Patrol,
        Chase,
        Attack
    }

    Estados _currentState = Estados.Patrol;

    SpriteRenderer m_spriteRenderer;
    Color oldColor= Color.black;
    void Start()
    {

        EnterState();
    }

    void Update()
    {
        UpdateState();
    }

    void EnterState()
    {
        switch (_currentState)
        {
            case Estados.Patrol:
                m_spriteRenderer.color = Color.red;
                break;
            case Estados.Chase:
                m_spriteRenderer.color = Color.blue;

                break;
            case Estados.Attack:
                break;
        }
    }
    void ExitState()
    {
        switch (_currentState)
        {
            case Estados.Patrol:
                m_spriteRenderer.color = oldColor;
                break;
            case Estados.Chase:
                break;
            case Estados.Attack:
                break;
        }
    }
    void UpdateState()
    {
        switch (_currentState) 
        {
            case Estados.Patrol:
                //Pulsar Tecla---- Cambiar
                break;
            case Estados.Chase:
                break; 
            case Estados.Attack:
                break;
        }
    }
    
    void ChangeStates(Estados NewState)
    {
        if (NewState == _currentState)
        {

        }
        ExitState();
    }
}
