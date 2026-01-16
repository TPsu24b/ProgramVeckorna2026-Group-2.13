using Unity.VisualScripting;
using UnityEngine;

public class SwitchLights : MonoBehaviour
{
    [SerializeField] GameObject greenLight;
    Light lightToToggle;
    private void Start()
    {
        lightToToggle = GetComponent<Light>();
    }
    public void UpdateLightToggle()
    {
        greenLight.SetActive(!greenLight.activeSelf);
        if(greenLight.activeSelf)
            lightToToggle.intensity = 1;
        else 
            lightToToggle.intensity = 0;
    }
}
