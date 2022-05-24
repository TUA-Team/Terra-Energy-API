using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraEnergy.Content.Capacitors;

namespace TerraEnergy.Interface {
    interface ITECapacitorLinkable
    {
        void LinkToCapacitor(BaseCapacitorTE capacitor);
    }
}
