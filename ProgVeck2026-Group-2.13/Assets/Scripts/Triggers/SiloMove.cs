using UnityEngine;

public class SiloMove : MonoBehaviour
{
    [SerializeField] private float speed, minY, maxY;
    void FixedUpdate()
    {
        transform.position += new Vector3(0, speed, 0);
        if(transform.position.y > maxY)
        {
            transform.position = new Vector3(0, minY, 0);
        }
    }
}
