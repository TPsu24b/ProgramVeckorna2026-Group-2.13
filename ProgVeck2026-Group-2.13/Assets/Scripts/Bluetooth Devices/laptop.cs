using UnityEngine;
using UnityEngine.InputSystem;

public class laptop : MonoBehaviour
{
    [SerializeField] GameObject loadingIcon, popUp;
    bool inRange = false;
    [SerializeField] InputActionReference interaction;
    void Update()
    {
        if(inRange && interaction.action.WasPerformedThisFrame())
        {
            loadingIcon.SetActive(!inRange);
            popUp.SetActive(inRange);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }

}
