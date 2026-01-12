using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Bluetooth_Devices
{
    internal class SwitchReciever : UniversalReciever
    {
        public bool mode = false;
        public override void Use()
        {
            mode = true;
        }
    }
}
