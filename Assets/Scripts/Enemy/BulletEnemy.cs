
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
   
    public int damage;
    public float speed;

    void Update()
    {
        transform.Translate(Time.deltaTime*speed*Vector2.right);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerLife playerLife))
        {
            playerLife.TakeDamage(damage);
        }
    }
}
