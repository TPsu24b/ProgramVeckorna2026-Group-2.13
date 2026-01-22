using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Output : SwitchReciever
{
    [SerializeField] SwitchReciever[] reciever;
    [SerializeField] GameObject popUp;
    [SerializeField] SwitchLights[] switchLights;
    [SerializeField] AudioSource audioSource;
    public bool active;
    
    public override void Use()
    {
        audioSource.Play();
        active = !active;
        foreach(SwitchReciever reciever in reciever)
            reciever.Use();
        foreach(SwitchLights light in switchLights)
            light.UpdateLightToggle();
        if(GetComponentInParent<DoorManager>() != null)
            GetComponentInParent<DoorManager>().UpdateDoorState();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(popUp != null)
                popUp.SetActive(true);
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(popUp != null)
                popUp.SetActive(false);
        }
    } 
}


