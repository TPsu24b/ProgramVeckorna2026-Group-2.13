using UnityEngine;
using UnityEngine.InputSystem;

public class Trigger : MonoBehaviour
{
    [SerializeField] private ASyncLoader sceneLoader;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sceneLoader.LoadLevelBtn("");
        }
    }
}
