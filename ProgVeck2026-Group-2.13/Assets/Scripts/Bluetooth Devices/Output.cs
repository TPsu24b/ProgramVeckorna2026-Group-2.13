using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Bluetooth_Devices
{
    internal class Output:energy
    {
        Rigidbody recieverRB;
        Rigidbody parentRB;
        public override void Use()
        {
            base.Use();
            recieverRB = mainReciever.GetComponent<Rigidbody>();
            parentRB = parent.GetComponent<Rigidbody>();

            if (GetDistance(recieverRB.position, parentRB.position) < 1)
            {
                
            }
        }
    }
}
