using System.Collections;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float life = 10;
    public float invulnerabilityTime;
    private float invulnerabilityTimeinitial;
    private bool isInvulnerable = false;
    Animator _anim;
    public AudioClip recivehitclip;
    [SerializeField]
    private string _reciveDamage = "ReciveDamage";
    [SerializeField]
    private string _die = "Die";

    private void Start()
    {
        _anim = GetComponent<Animator>();
        invulnerabilityTimeinitial = invulnerabilityTime;
        VictoryCondition.instance.RegisterEnemy(this);
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

    public void TakeDamage(float damage)
    {
        if (isInvulnerable)
        {
            return;
        }

        _anim.SetTrigger(_reciveDamage);
        life -= damage;
        AudioManager.Instance.ReproducirSonido(recivehitclip);


        if (life <= 0)
        {
            StartCoroutine(Die());
        }
        else
        {
            isInvulnerable = true;
            invulnerabilityTime = invulnerabilityTimeinitial;
        }
    }

    private IEnumerator Die()
    {
        _anim.SetTrigger(_die);
        yield return new WaitForSeconds(_anim.GetCurrentAnimatorStateInfo(0).length);
        VictoryCondition.instance.UnregisterEnemy(this);
        Destroy(gameObject);
    }
}
