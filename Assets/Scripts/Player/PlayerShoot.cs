using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform mira;
    public GameObject bullet;
    public Transform start;
    public float bulletSpeed = 10f; 

    private PlayerMovment playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovment>();
    }

    void Update()
    {
        mira.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));
        Vector3 direction = (mouseWorldPosition - start.position).normalized;

        if ((mouseWorldPosition.x < transform.position.x && playerMovement.mirandoDerecha) ||
            (mouseWorldPosition.x > transform.position.x && !playerMovement.mirandoDerecha))
        {
            playerMovement.Orientacion(mouseWorldPosition.x - transform.position.x);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot(direction);
        }
    }

    void Shoot(Vector3 direction)
    {
        GameObject shoot = Instantiate(bullet, start.position, Quaternion.identity);
        shoot.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed; // Asume que tienes una variable bulletSpeed definida.
        Destroy(shoot, 5f);
    }
}
