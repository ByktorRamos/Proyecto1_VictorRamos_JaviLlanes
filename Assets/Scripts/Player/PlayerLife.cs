using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public GameObject dieMenu;
    public int life = 10;
    public float invulnerabilityTime;
    private float invulnerabilityTimeinitial;
    private bool isInvulnerable = false;
    Animator _anim;
    public GameObject arm;
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
            arm.SetActive(false);
            StartCoroutine(Die());
            dieMenu.SetActive(true);
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
        _anim.SetTrigger("Die");
        yield return new WaitForSeconds(_anim.GetCurrentAnimatorStateInfo(0).length);
        this.gameObject.SetActive(false);
       // Destroy(gameObject);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
