using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class DistanceAttack : MonoBehaviour
{

    private float timer;
    private bool rangeplayer;
    private bool rangeplayerdEspalda;
    public LayerMask playerLayer;
    private Transform player;


    public Transform bulletpos;
    public Transform espalda;
    public float detectionEsplada;
    public float proba = 6;

    private bool mirandoder = true;
    private bool probamos=true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void AttackDistance(Transform bulletpos, float detectionrange, float shootcooldown, GameObject bullet, Animator _anim)
    {
        rangeplayer = Physics2D.Raycast(bulletpos.position, transform.right, proba, playerLayer);
        rangeplayerdEspalda = Physics2D.Raycast(espalda.position, transform.right * -1, detectionEsplada, playerLayer);

        if (rangeplayer)
        {
            //Debug.Log("EnFrente");
            Debug.Log(probamos);
            Debug.Log(rangeplayer+"Rangeplayer");

            Shoot(bullet, bulletpos, _anim, shootcooldown);
        }
        

        if (rangeplayerdEspalda) 
        {
            //Debug.Log("EnLaEspalda");
            Girar();
           // probamos=false;
            Debug.Log(probamos);
        }
       /* if (!rangeplayer && probamos == false)
        {
            Debug.Log("Jugador fuera de rango");
            Girar();
        }*/

    }

    private void Girar()
    {
        mirandoder = !mirandoder;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        //speed *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(bulletpos.position, bulletpos.position + transform.right * proba);

        Gizmos.color = Color.red;

        Gizmos.DrawLine(espalda.position, espalda.position + transform.right * -1 * detectionEsplada);
    }

    void Shoot(GameObject bullet, Transform bulletpos, Animator _anim, float shootcooldown)
    {
        timer += Time.deltaTime;
        if (timer > shootcooldown)
        {
            timer = 0;
            _anim.SetTrigger("Shoot");
            Instantiate(bullet, bulletpos.position, bulletpos.rotation);
        }
        
    }

}