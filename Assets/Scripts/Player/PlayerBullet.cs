using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float damage;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyLife enemyLife))
        {
            enemyLife.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);

    }
}
