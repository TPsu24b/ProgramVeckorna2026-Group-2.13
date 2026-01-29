using UnityEngine;
using UnityEngine.InputSystem;

public class laptop : Output
{
    [SerializeField] GameObject loadingIcon;
    bool inRange = false;
    [SerializeField] InputActionReference interaction;
    public override void Use()
    {
        loadingIcon.SetActive(!loadingIcon.activeSelf);
        popUp.SetActive(!popUp.activeSelf);
    }

}
