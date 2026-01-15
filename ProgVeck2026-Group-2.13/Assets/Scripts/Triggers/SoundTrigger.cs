using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    }
}
