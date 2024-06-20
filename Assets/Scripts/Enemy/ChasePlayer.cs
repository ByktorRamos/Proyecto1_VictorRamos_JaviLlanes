using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public void Chaseplayers(float speed, GameObject player, Rigidbody2D rb)
    {
       
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
