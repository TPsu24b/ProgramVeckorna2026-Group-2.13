using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public List<Output> recievers = new List<Output>();
    [SerializeField] private SwitchReciever door;
    public void UpdateDoorState()
    {
        bool allActive = true;
        foreach(Output reciever in recievers)
        {
            if(!reciever.active)
            {
                allActive = false;
                break;
            }
        }
        if(allActive)
            door.Use();
    }

}