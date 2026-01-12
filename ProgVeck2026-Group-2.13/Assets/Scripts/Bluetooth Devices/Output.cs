using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
public class Output : energy
{
    public GameObject reciever;
    public override void Use()
    {
        reciever.GetComponent<SwitchReciever>().Use();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Reciver")
            reciever.GetComponent<SwitchReciever>().Use();
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Reciver")
            reciever.GetComponent<SwitchReciever>().Use();
    }
}

