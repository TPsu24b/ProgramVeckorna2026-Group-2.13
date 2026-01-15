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

    public virtual void Use()
    {
        
    }

}