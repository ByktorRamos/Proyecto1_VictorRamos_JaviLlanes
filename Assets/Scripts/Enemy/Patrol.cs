using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    public LayerMask capaAbajo;
    public LayerMask capaEnfrente;
    public float distanciaabajo;
    public float distanciafrente;
    public Transform contrabajo; 
    public Transform contrfrente;
    private bool infoabajo;
    private bool infofrente;
    private bool mirandodre=true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Patrolfunc();
    }

    public void Patrolfunc()
    {
        _rb.velocity = new Vector2(speed, _rb.velocity.y);

        // infofrente = Physics2D.Raycast(contrfrente.position, Vector2.right, distanciafrente, capaEnfrente);
        infofrente = Physics2D.Raycast(contrfrente.position, transform.right, distanciafrente, capaEnfrente);

        //infoabajo = Physics2D.Raycast(contrabajo.position, Vector2.down, distanciaabajo, capaAbajo);
        infoabajo = Physics2D.Raycast(contrabajo.position, transform.up * -1, distanciaabajo, capaAbajo);

        if (infofrente || !infoabajo)
        {
            Girar();
        }
    }
    private void Girar()
    {
        mirandodre = !mirandodre;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y +180, 0);
        speed *= -1;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(contrabajo.transform.position, contrabajo.transform.position + transform.up * -1 * distanciaabajo);
        Gizmos.DrawLine(contrfrente.transform.position, contrfrente.transform.position + transform.right * distanciafrente);
    }*/
   
}
