using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private ASyncLoader sceneLoader;
    public string sceneToLoad;
    public bool delay;
    public float timeDelay;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(delay) 
                StartCoroutine(DelayLoad());
            else
                sceneLoader.LoadLevelBtn(sceneToLoad);
        }
    }
    IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(timeDelay);
        sceneLoader.LoadLevelBtn(sceneToLoad);
    }
}
