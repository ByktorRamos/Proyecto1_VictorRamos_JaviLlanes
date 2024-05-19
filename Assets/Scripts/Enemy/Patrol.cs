using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float disFloorDetection = 2;
    private float disObstacleDetection = 2;

    private bool infFloor;
    private bool infObstacles;

    public void Patrolfunc(LayerMask layerFloor, LayerMask layerobstacles, Transform contrfloor, Transform contrObst, Rigidbody2D _rb, ref bool mirandoder)
    {
        _rb.velocity = new Vector2(mirandoder ? speed : -speed, _rb.velocity.y);

        infObstacles = Physics2D.Raycast(contrObst.position, transform.right, disObstacleDetection, layerobstacles);
        infFloor = Physics2D.Raycast(contrfloor.position, Vector2.down, disFloorDetection, layerFloor);

        if (infObstacles || !infFloor)
        {
            Girar(ref mirandoder);
        }
    }

    private void Girar(ref bool mirandoder)
    {
        mirandoder = !mirandoder;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }
    /*
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(contrfloor.transform.position, contrfloor.transform.position + transform.up * -1 * disFloorDetection);
        Gizmos.DrawLine(contrObst.transform.position, contrObst.transform.position + transform.right * fisObstacleDetection);
    }
# endif*/
}
