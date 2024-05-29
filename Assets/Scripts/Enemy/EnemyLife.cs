using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLife : MonoBehaviour
{
    public float life = 10;
    public float invulnerabilityTime;
    private float invulnerabilityTimeinitial;
    private bool isInvulnerable = false;
    Animator _anim;
    public AudioClip recivehitclip;


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

        _anim.SetTrigger("ReciveDamage");
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
        _anim.SetTrigger("Die");
        yield return new WaitForSeconds(_anim.GetCurrentAnimatorStateInfo(0).length);
        VictoryCondition.instance.UnregisterEnemy(this);
        Destroy(gameObject);
    }
}
