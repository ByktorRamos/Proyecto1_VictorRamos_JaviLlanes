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
    public AudioClip recivedamageclip;
    public AudioClip DeathClip;
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
        _anim.SetTrigger("Die");
        yield return new WaitForSeconds(_anim.GetCurrentAnimatorStateInfo(0).length);
        this.gameObject.SetActive(false);
        PausarJuego();
        // Destroy(gameObject);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void PausarJuego()
    {
        Time.timeScale = 0f;
        dieMenu.SetActive(true);

    }

}
