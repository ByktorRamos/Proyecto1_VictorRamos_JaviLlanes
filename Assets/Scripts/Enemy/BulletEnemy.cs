
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
   
    public int damage;
    public float speed;
    public float destroybullet = 5;

    private void Start()
    {
        Destroy(this.gameObject, destroybullet);
    }
    void Update()
    {
        transform.Translate(Time.deltaTime*speed*Vector2.right);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerLife playerLife))
        {
            playerLife.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);

    }
}
