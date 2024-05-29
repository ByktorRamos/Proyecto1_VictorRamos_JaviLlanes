using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Prueba();
    }
    private void Prueba()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
