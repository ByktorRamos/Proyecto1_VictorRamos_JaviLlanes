using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private string m_playerName = "Player";
    private GameObject player;
    private Rigidbody _rigidbody;
    public float force;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag(m_playerName);

        Vector3 direction = player.transform.position - transform.position;
        _rigidbody.velocity= new Vector2(direction.x, direction.y).normalized*force;
        
    }

    void Update()
    {
        
    }
}
