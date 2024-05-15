using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int life = 10;
    public float invulnerabilityTime;
    private float invulnerabilityTimeinitial;
    private bool isInvulnerable = false;
    Animator _anim;

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
        // Si el jugador esta invulnerable, sal de la funcion sin recibir damage
        if (isInvulnerable)
        {
            return;
        }
        _anim.SetTrigger("ReciveDamage");
        life -= damage;

        if (life <= 0)
        {
            _anim.SetTrigger("Die");
            Destroy(gameObject);
        }
        else
        {
            isInvulnerable = true;
            invulnerabilityTime = invulnerabilityTimeinitial; 
        }
    }
}
