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
        public Rigidbody recieverRB;
        public Rigidbody parentRB;
        public  SwitchReciever reciever;

        private void Start()
        {
            recieverRB = reciever.GetComponent<Rigidbody>();
            parentRB = parent.GetComponent<Rigidbody>();
        }
        private void Update()
        {
            if (GetDistance(recieverRB.position, parentRB.position) < 1)
            {
                reciever.Use();
            }
        }
        public override void Use()
        {
            reciever.Use();
        }
    }
}
