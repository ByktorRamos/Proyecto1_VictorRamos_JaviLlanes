using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSB : MonoBehaviour
{
    //StateMachine patrolState;
    //StateMachine _currentState;
    private string m_playerName = "Player";
    private GameObject player;

    public GameObject bullet;
    public Transform bulletpos;
    public float shootcooldawn = 2;
    public float detectionrange = 10;

    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(m_playerName);

    }

    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance > detectionrange)
        {
            timer += Time.deltaTime;
        }

        if (timer> shootcooldawn)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet,bulletpos.position, Quaternion.identity);

    }
}
