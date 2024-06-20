
using UnityEngine;

public class Camaramovment : MonoBehaviour
{
    public GameObject player;
  

    void Update()
    {
        Vector3 posicionplayer = transform.position;
        posicionplayer.x = player.transform.position.x;
        posicionplayer.y = player.transform.position.y;
         transform.position=posicionplayer;
    }
}
