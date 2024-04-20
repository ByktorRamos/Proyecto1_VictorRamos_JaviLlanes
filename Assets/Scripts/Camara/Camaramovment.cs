using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaramovment : MonoBehaviour
{
    public GameObject player;
    private Transform camara;
    // Start is called before the first frame update
    void Start()
    {
      // camara= GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicionplayer = transform.position;
        posicionplayer.x = player.transform.position.x;
        posicionplayer.y = player.transform.position.y;
         transform.position=posicionplayer;
    }
}
