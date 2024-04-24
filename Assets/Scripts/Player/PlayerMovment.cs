using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    private string _horizontalInputAxis = "Horizontal";
    //[SerializeField]
    //private string _verticalInputAxis = "Vertical";
    private Vector3 _desiredDirection = Vector3.zero;


    private BoxCollider2D _boxCollider;
    private new Rigidbody2D rigidbody;
    public float speed;
    public float fuerzaSalto;
    public LayerMask suelo;

    private Animator anim;

    private bool mirandoDerecha = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Salto();
    }

    void Movimiento()
    {
        _desiredDirection.x = Input.GetAxis(_horizontalInputAxis);

        AnimacionRun(_desiredDirection.x);

        rigidbody.velocity = new Vector3(_desiredDirection.x * speed,rigidbody.velocity.y);
      

        Orientacion(_desiredDirection.x);
    }

    void AnimacionRun(float inputmov)
    {
        if (inputmov != 0f)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    void Orientacion(float desiredDirection)
    {
        if ((mirandoDerecha == true && desiredDirection < 0) || (mirandoDerecha == false && desiredDirection > 0))
        {

            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }


    bool TocandoSuelo()
    {
        Vector2 size = new Vector2(_boxCollider.bounds.size.x, _boxCollider.bounds.size.y);
        // Caja para detectar si el jugador toca con el suelo o no
        RaycastHit2D raycastbox= Physics2D.BoxCast(_boxCollider.bounds.center, size,0f,Vector2.down,0.2f,suelo);
       
        return raycastbox.collider != null;
    }

    void Salto()
    {
        if(Input.GetKeyDown(KeyCode.Space) && TocandoSuelo()) 
        {
            rigidbody.AddForce(Vector2.up * fuerzaSalto,ForceMode2D.Impulse);
        }
    }

    // Cambia la orientacion hacia donde mira el personaje

    

}
