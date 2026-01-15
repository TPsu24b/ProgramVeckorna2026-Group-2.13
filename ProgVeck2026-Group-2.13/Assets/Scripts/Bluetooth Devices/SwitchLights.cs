using Unity.VisualScripting;
using UnityEngine;

public class SwitchLights : MonoBehaviour
{
    [SerializeField] GameObject greenLight;
    Light light;
    private void Start()
    {
        light = GetComponent<Light>();
    }
    void Update()
    {
        //sets lights on or off depending on if active in parent is true or false
        if (GetComponentInParent<Output>().active)
        {
            light.intensity = 0;
            greenLight.SetActive(true);
        }
        else
        {
            light.intensity = 1;
            greenLight.SetActive(false);
        }
    }
}
