
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
    

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PlayerLife playerLife))
        {
            playerLife.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);

    }
}
