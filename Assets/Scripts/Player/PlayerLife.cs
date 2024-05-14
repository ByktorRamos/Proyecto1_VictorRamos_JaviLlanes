using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int life = 10;
    public float invulnerabilityTime;
    private float invulnerabilityTimeinitial;
    private bool isInvulnerable = false;


    private void Start()
    {
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
        // Si el jugador está invulnerable, sal de la función sin recibir daño
        if (isInvulnerable)
        {
            return;
        }

        life -= damage;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            isInvulnerable = true;
            invulnerabilityTime = invulnerabilityTimeinitial; 
        }
    }
}
