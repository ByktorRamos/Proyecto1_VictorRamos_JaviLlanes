using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttack : MonoBehaviour
{
    
    private float timer;
    private bool rangeplayer;
    public LayerMask playerLayer;

    
    public void AttackDistance(Transform bulletpos, float detectionrange, float shootcooldawn,GameObject bullet,Animator _anim)
    {
        rangeplayer = Physics2D.Raycast(bulletpos.position, transform.right, detectionrange, playerLayer);
        //float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (rangeplayer)
        {
            timer += Time.deltaTime;
        }

        if (timer > shootcooldawn)
        {
            timer = 0;
            _anim.SetTrigger("Shoot");
            Shoot(bullet, bulletpos);
        }
    }
    void Shoot(GameObject bullet, Transform bulletpos)
    {
        Instantiate(bullet,bulletpos.position, bulletpos.rotation);

    }
    
}
