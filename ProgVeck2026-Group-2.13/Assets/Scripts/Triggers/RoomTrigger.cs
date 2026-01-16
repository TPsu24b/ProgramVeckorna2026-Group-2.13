using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    void OnTriggerEnter(Collider other)
    {
        foreach(GameObject obj in gameObjects)
            obj.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        foreach(GameObject obj in gameObjects)
            obj.SetActive(false);
    }
}
