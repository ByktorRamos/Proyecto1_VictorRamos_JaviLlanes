using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cam;
    Vector3 camStartPos;
    // Distancia entre la posicion de comienzo de la camara y su posicion actual
    float distance;

    GameObject[] backgrounds;
    Material[] mat;
    float[] backspeed;

    float farthestBack;

    [Range(0.01f,0.05f)]
    public float parallaxspeed;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;
        
        int backCount= transform.childCount;
        mat = new Material[backCount];
        backspeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for(int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;   
        }
        BackSpeed(backCount);
    }

    void BackSpeed(int backCount)
    {
        for(int i = 0;i < backCount;i++) //busca el fondo mas lejano
        {
            if ((backgrounds[i].transform.position.z - cam.position.z) > farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }
        for(int i = 0;i< backCount; i++) // aplica la velocidad a los diferentes fondos
        {
            backspeed[i] = 1 - (backgrounds[i].transform.position.z-cam.position.z) / farthestBack;
        }
    }

    private void LateUpdate()
    {
        distance = cam.position.x - camStartPos.x;
        transform.position = new Vector3(cam.position.x,transform.position.y,0);
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backspeed[i] * parallaxspeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0)*speed);
        }
    }
}
