using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        deathScreen.SetActive(true);
    }
}
