using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class energy : MonoBehaviour
{
    public List<UniversalReciever> recieversList = new List<UniversalReciever>();

    Output output;

    public enum Type {output, conducter, battery};
    public Type energyType;
    [SerializeField] protected UniversalReciever mainReciever;
    int previousedistance;
    void Start()
    {
        foreach(UniversalReciever obj in recieversList)
        {
            int i = GetDistance(obj.transform.position, transform.position);
            if (i < previousedistance)
            {
                previousedistance = i;
                mainReciever = obj;
            }
        } 
    }
    public virtual void Use()
    {
        
    }
    //Gets distance of objecy (pythagoras)
    public int GetDistance(Vector3 pos1, Vector3 pos2)
    {
        return (int)Math.Sqrt(Math.Pow(pos1.x - pos2.x, 2) + Math.Pow(pos1.y - pos2.y, 2) + Math.Pow(pos1.z - pos2.z, 2));
    }
}