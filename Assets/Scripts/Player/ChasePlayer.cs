using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
   // public Transform player;
    public float chaseRange = 5f; // Distancia a partir de la cual el enemigo persigue al jugador
    public float speed = 3f; // Velocidad de movimiento del enemigo

    private string m_playerName = "Player";
    private GameObject player;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag(m_playerName);

    }

    void Update()
    {
        // Calcula la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Si el jugador está dentro del rango de persecución, persigue al jugador
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
