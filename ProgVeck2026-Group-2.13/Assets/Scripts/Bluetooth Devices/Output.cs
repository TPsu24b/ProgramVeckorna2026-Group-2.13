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
    [SerializeField] InputActionReference interaction;
    bool interactable;
    public override void Use()
    {
        foreach(SwitchReciever reciever in reciever)
            reciever.Use();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            interactable = true;
            popUp.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            interactable = false;
            popUp.SetActive(false);
        }
    }
    void Update()
    {
        if(interaction.action.WasPerformedThisFrame() && interactable)
        {
            foreach(SwitchReciever reciever in reciever)
                reciever.GetComponent<SwitchReciever>().Use();

        }
    }    
}


