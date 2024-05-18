using UnityEngine;


public class DistanceAttack : MonoBehaviour
{

    private float timer;
    private bool rangeplayer;
    private bool rangeplayerdEspalda;
    public LayerMask playerLayer;
    

    public Transform bulletpos;
    public Transform espalda;
    public float detectionEsplada;

    public float detectionrange;

   

    public void AttackDistance(Transform bulletpos, float attackRange, float shootcooldown, GameObject bullet, Animator _anim, ref bool mirandoder)
    {
        rangeplayer = Physics2D.Raycast(bulletpos.position, transform.right, attackRange, playerLayer);
        rangeplayerdEspalda = Physics2D.Raycast(espalda.position, transform.right * -1, detectionEsplada, playerLayer);

        if (rangeplayer)
        {
            Shoot(bullet, bulletpos, _anim, shootcooldown);
        }

        if (rangeplayerdEspalda)
        {
            Girar(ref mirandoder);
        }

        if (!rangeplayer && !rangeplayerdEspalda && !mirandoder)
        {
            Girar(ref mirandoder);
        }
    }

    private void Girar(ref bool mirandoder)
    {
        mirandoder = !mirandoder;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(bulletpos.position, bulletpos.position + transform.right * detectionrange);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(espalda.position, espalda.position + transform.right * -1 * detectionEsplada);
    }

    void Shoot(GameObject bullet, Transform bulletpos, Animator _anim, float shootcooldown)
    {
        timer += Time.deltaTime;
        if (timer > shootcooldown)
        {
            timer = 0;
            _anim.SetTrigger("Shoot");
            Instantiate(bullet, bulletpos.position, bulletpos.rotation);
        }
    }

}