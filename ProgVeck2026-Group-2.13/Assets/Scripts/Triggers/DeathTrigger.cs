using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    void OnTriggerEnter(Collider other)
    {
        deathScreen.SetActive(true);
    }
}
