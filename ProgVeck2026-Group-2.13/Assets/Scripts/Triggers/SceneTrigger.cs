using UnityEngine;
using UnityEngine.InputSystem;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private ASyncLoader sceneLoader;
    [SerializeField] SaveManager saveManager;
    public string sceneToLoad;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(saveManager != null)
                saveManager.SaveData(sceneToLoad);
            sceneLoader.LoadLevelBtn(sceneToLoad);
        }
    }
}
