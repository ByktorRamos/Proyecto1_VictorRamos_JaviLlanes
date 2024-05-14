using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    
  
    public void Chaseplayers(float speed, GameObject player)
    {

        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
        /*if (distanceToPlayer < chaseRange)
        {
           
        }*/
        
    }
}
