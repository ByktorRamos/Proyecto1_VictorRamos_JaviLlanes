using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotate : MonoBehaviour
{
    Vector3 mousepos;
    Vector3 gunpos;

    private PlayerMovment playerMovement;

    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovment>();
    }

    void Update()
    {
        mousepos = Input.mousePosition;
        gunpos = Camera.main.WorldToScreenPoint(transform.position);
        mousepos.x = mousepos.x - gunpos.x;
        mousepos.y = mousepos.y - gunpos.y;
        float gunangle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg;

        if (playerMovement.mirandoDerecha)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, gunangle));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(180f, 0f, -gunangle));
        }
    }
}
