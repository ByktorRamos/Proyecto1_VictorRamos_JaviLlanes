using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSB : MonoBehaviour
{
    
    private string m_playerName = "Player";
    private GameObject player;

    public GameObject bullet;
    public Transform bulletpos;
    public float shootcooldawn = 2;
    public float detectionrange = 10;

    private float timer;
    private bool rangeplayer;
    public LayerMask playerLayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(m_playerName);

    }

    void Update()
    {
        rangeplayer = Physics2D.Raycast(bulletpos.position, transform.right, detectionrange, playerLayer );
       //float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (rangeplayer)
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
        Instantiate(bullet,bulletpos.position, bulletpos.rotation);

    }
    
}
