using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Output : energy
{
    [SerializeField] GameObject reciever, popUp;
    [SerializeField] InputActionReference interaction;
    bool interactable;
    public override void Use()
    {
        reciever.GetComponent<SwitchReciever>().Use();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Reciver")
        {
            interactable = true;
            popUp.SetActive(true);
            StartCoroutine(PlayerInsideHitBox());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Reciver")
        {
            interactable = false;
            popUp.SetActive(false);
        }
    }
    IEnumerator PlayerInsideHitBox()
    {
        if(interaction.action.IsPressed())
        {
            reciever.GetComponent<SwitchReciever>().Use();
        }
        else 
            yield return StartCoroutine(PlayerInsideHitBox());
    }    
}


