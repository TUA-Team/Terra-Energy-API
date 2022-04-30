using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraEnergy.TileEntities;

namespace TerraEnergy.Interface
{
    interface ITECapacitorLinkable
    {
        void LinkToCapacitor(CapacitorTE capacitor);
    }
}
