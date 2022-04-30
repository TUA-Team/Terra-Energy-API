using TerraEnergy.EnergyAPI;

namespace TerraEnergy.Items {
    public class TerraMeter : EnergyItem {
        public override void SafeSetDefault(ref int maxEnergy) {
            maxEnergy = 100000;
            item.width = 30;
            item.height = 30;
            item.consumable = false;
            item.useStyle = 4;
        }
    }
}