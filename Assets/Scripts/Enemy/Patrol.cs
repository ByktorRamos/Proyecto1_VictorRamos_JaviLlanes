using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    /* private Rigidbody2D _rb;

     public float speed;
     public LayerMask layerFloor;
     public LayerMask layerobstacles;
     public Transform contrfloor;
     public Transform contrObst;*/
    public float speed;
    private float disFloorDetection = 2;
    private float disObstacleDetection = 2;

    private bool infFloor;
    private bool infObstacles;
    private bool mirandodre=true;

    /*private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        Patrolfunc();
    }*/

    public void Patrolfunc(LayerMask layerFloor, LayerMask layerobstacles,Transform contrfloor, Transform contrObst, Rigidbody2D _rb)
    {

        _rb.velocity = new Vector2(speed, _rb.velocity.y);

        // infofrente = Physics2D.Raycast(contrfrente.position, Vector2.right, distanciafrente, capaEnfrente);
        infObstacles = Physics2D.Raycast(contrObst.position, transform.right, disObstacleDetection, layerobstacles);

        //infoabajo = Physics2D.Raycast(contrabajo.position, Vector2.down, distanciaabajo, capaAbajo);
        infFloor = Physics2D.Raycast(contrfloor.position, transform.up * -1, disFloorDetection, layerFloor);

        if (infObstacles || !infFloor)
        {
            Girar();
        }
    }
    private void Girar()
    {
        mirandodre = !mirandodre;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        speed *= -1;
    }
    /*
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(contrfloor.transform.position, contrfloor.transform.position + transform.up * -1 * disFloorDetection);
        Gizmos.DrawLine(contrObst.transform.position, contrObst.transform.position + transform.right * fisObstacleDetection);
    }
# endif*/
}
