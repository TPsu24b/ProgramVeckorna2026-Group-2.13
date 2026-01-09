using UnityEngine;

public class SinglePoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<SavePointManager>().UpdateSavePoint(other.gameObject.transform);
    }
}
