using Assets.Scripts.Bluetooth_Devices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class energy : MonoBehaviour
{
    public List<GameObject> recieversList = new List<GameObject>();

    Output output;
    Conducter conducter;
    Battery battery;
    

    public bool outputType, conducterType, batteryType;
    [SerializeField]
    protected GameObject mainReciever, parent; 
    int previousedistance;
    void Start()
    {
        foreach(GameObject obj in recieversList)
        {
            int i = GetDistance(obj.transform.position, transform.position);
            if (i < previousedistance)
            {
                previousedistance = i;
                mainReciever = obj;
            }
        } 
    }
    void Update()
    {
        
    }
    public virtual void Use()
    {
        
    }

    public int GetDistance(Vector3 pos1, Vector3 pos2)
    {
        return (int)Math.Sqrt(Math.Pow(pos1.x - pos2.x, 2) + Math.Pow(pos1.y - pos2.y, 2) + Math.Pow(pos1.z - pos2.z, 2));
    }
}