using Unity.Mathematics;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] float spinSpeed;
    void FixedUpdate()
    {
        transform.Rotate(0,spinSpeed,0);
    }
}
