using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    private string _horizontalInputAxis = "Horizontal";
    [SerializeField]
    private string _verticalInputAxis = "Vertical";
    private Vector3 _desiredDirection = Vector3.zero;

    private bool climbing;
    private float gravedadinicial;
    public float speedClimb;


    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidbody;
    public float speed;
    public float fuerzaSalto;
    public LayerMask suelo;

    private Animator _anim;

    private bool mirandoDerecha = true;





    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        gravedadinicial = _rigidbody.gravityScale;

    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetFloat("VelocidadY",_rigidbody.velocity.y);


        Movimiento();
        Salto();
        Escalar();
    }

    void Movimiento()
    {
        _desiredDirection.x = Input.GetAxis(_horizontalInputAxis);
        _desiredDirection.y = Input.GetAxis(_verticalInputAxis);

        AnimacionRun(_desiredDirection.x);

        _rigidbody.velocity = new Vector3(_desiredDirection.x * speed,_rigidbody.velocity.y);
      

        Orientacion(_desiredDirection.x);
    }

    void AnimacionRun(float inputmov)
    {
        if (inputmov != 0f)
        {
            _anim.SetBool("Run", true);
        }
        else
        {
            _anim.SetBool("Run", false);
        }
    }

    // Cambia la orientacion hacia donde mira el personaje
    void Orientacion(float desiredDirection)
    {

        if ((mirandoDerecha == true && desiredDirection < 0) || (mirandoDerecha == false && desiredDirection > 0))
        {
            mirandoDerecha= !mirandoDerecha;
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
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
            _rigidbody.AddForce(Vector2.up * fuerzaSalto,ForceMode2D.Impulse);
            _anim.SetTrigger("Jump");
        }
        _anim.SetBool("OnGround", TocandoSuelo());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stairs")
        {
            _desiredDirection.y = Input.GetAxis(_verticalInputAxis);
           
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _desiredDirection.y * speed);
            Debug.Log("Choca");
        }
    }

    private void Escalar()
    {
        if ((_desiredDirection.y != 0|| climbing)&&(_boxCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))) 
        {
            Vector2 velocidadsubida = new Vector2(_rigidbody.velocity.x, _desiredDirection.y * speedClimb);
            _rigidbody.velocity = velocidadsubida;
            _rigidbody.gravityScale = 0;
            climbing = true;
        }
        else
        {
            _rigidbody.gravityScale = gravedadinicial;
            climbing=false;
        }
        if (TocandoSuelo())
        {
            climbing = false;
        }

        _anim.SetBool("Climbing", climbing);
        //_anim.SetBool("OnGround", TocandoSuelo());

    }

}
