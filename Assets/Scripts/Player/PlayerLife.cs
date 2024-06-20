using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int life = 10;
    public float invulnerabilityTime;
    private float invulnerabilityTimeinitial;
    private bool isInvulnerable = false;
    Animator _anim;
    public GameObject arm;
    public AudioClip recivedamageclip;
    public AudioClip DeathClip;

    [SerializeField]
    private string _reciveDamage = "ReciveDamage";
    [SerializeField]
    private string _die = "Die";
    private void Start()
    {
        _anim=GetComponent<Animator>();
        invulnerabilityTimeinitial= invulnerabilityTime;
    }
    private void Update()
    {
        
        if (isInvulnerable)
        {
            invulnerabilityTime -= Time.deltaTime;
            if (invulnerabilityTime <= 0f)
            {
                isInvulnerable = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
        {
            return;
        }

        _anim.SetTrigger(_reciveDamage);
        life -= damage;
        AudioManager.Instance.ReproducirSonido(recivedamageclip);

        if (life <= 0)
        {
            AudioManager.Instance.ReproducirSonido(DeathClip);
            StartCoroutine(Die());
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            isInvulnerable = true;
            invulnerabilityTime = invulnerabilityTimeinitial;
        }
    }

    private IEnumerator Die()
    {
        arm.SetActive(false);
        _anim.SetTrigger(_die);
        yield return new WaitForSeconds(_anim.GetCurrentAnimatorStateInfo(0).length);
        this.gameObject.SetActive(false);
        GamePauseManager.instance.DieGame();
        
    }
    

}
