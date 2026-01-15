using UnityEngine;
using UnityEngine.InputSystem;

public class laptop : MonoBehaviour
{
    [SerializeField] GameObject interact, text;
    bool inRange = false, isOpen;
    [SerializeField] InputActionReference interaction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange == true)
        {
            interact.SetActive(true);
            if (interaction.action.WasPerformedThisFrame())
            {
                text.SetActive(true);
            }
        }
        else
            interact.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        interact.SetActive(true);
        inRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        interact.SetActive(false);
        inRange = false;
    }

}
