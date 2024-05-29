using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public GameObject arm;
    ShootingGun _shooting;
    [SerializeField]
    private string _horizontalInputAxis = "Horizontal";
    [SerializeField]
    private string _verticalInputAxis = "Vertical";
    private Vector3 _desiredDirection = Vector3.zero;

    private bool climbing;
    private float initialgravity;
    public float speedClimb;


    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidbody;
    public float speed;
    public float jumpForce;
    public LayerMask floorlayerMask;


    private Animator _anim;

    public bool mirandoDerecha = true;


    [Header("Controles")]
    public KeyCode k_space = KeyCode.Space;

    [Header("Animaciones")]
    public string anim_velocidadY = "VelocidadY";
    public string anim_run = "Run";
    public string anim_jump = "Jump";
    public string anim_OnGround = "OnGround";
    public string anim_climbing = "Climbing";
   


    void Start()
    {
        _anim = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        initialgravity = _rigidbody.gravityScale;
        
        _shooting= GetComponent<ShootingGun>();
    }

    void Update()
    {
        _anim.SetFloat(anim_velocidadY, _rigidbody.velocity.y);


        Moverse();
        Salto();
        Escalar();
    }

    void Moverse()
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
            _anim.SetBool(anim_run, true);
        }
        else
        {
            _anim.SetBool(anim_run, false);
        }
    }

    // Cambia la orientacion hacia donde mira el personaje
    public void Orientacion(float desiredDirection)
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
        RaycastHit2D raycastbox= Physics2D.BoxCast(_boxCollider.bounds.center, size,0f,Vector2.down,0.2f,floorlayerMask);
       
        return raycastbox.collider != null;
    }

    void Salto()
    {
        if(Input.GetKeyDown(k_space) && TocandoSuelo()) 
        {
            _rigidbody.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
            _anim.SetTrigger(anim_jump);
        }
        _anim.SetBool(anim_OnGround, TocandoSuelo());
    }

   

    private void Escalar()
    {
        if ((_desiredDirection.y != 0|| climbing)&&(_boxCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))) 
        {
            Vector2 velocidadsubida = new Vector2(_rigidbody.velocity.x, _desiredDirection.y * speedClimb);
            _rigidbody.velocity = velocidadsubida;
            _rigidbody.gravityScale = 0;
            climbing = true;
            arm.SetActive(false);
            
        }
        else
        {
            _rigidbody.gravityScale = initialgravity;
            arm.SetActive(true);
            climbing = false;
        }
        if (TocandoSuelo())
        {
            arm.SetActive(true);
            climbing = false;
        }

        _anim.SetBool(anim_climbing, climbing);

    }

}
