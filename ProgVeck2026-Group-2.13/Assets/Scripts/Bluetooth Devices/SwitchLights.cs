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
        if (greenLight)
            Light. = false;
    }
}
