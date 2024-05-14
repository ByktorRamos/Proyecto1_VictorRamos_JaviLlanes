using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
   // public Transform player;
    public float chaseRange = 5f; 
    public float speed = 3f; 

    private string m_playerName = "Player";
    private GameObject player;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag(m_playerName);

    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < chaseRange)
        {
            Chaseplayers();
        }
    }

    public void Chaseplayers()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
