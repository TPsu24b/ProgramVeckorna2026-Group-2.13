using UnityEngine;
using UnityEngine.InputSystem;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private ASyncLoader sceneLoader;
    public string sceneToLoad;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            sceneLoader.LoadLevelBtn(sceneToLoad);
        }
    }
}
