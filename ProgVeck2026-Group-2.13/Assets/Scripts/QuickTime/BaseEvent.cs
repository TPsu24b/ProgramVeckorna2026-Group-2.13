using System;
using UnityEngine;
using UnityEngine.InputSystem;
[System.Serializable]
public class BaseEvent
{
    
    [SerializeField]
    public int lifeTime, keyToPress;
    [SerializeField]
    public Vector3 position; 
}
