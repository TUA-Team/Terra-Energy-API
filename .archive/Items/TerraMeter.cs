using TerraEnergy.EnergyAPI;

namespace TerraEnergy.Items {
    public class TerraMeter : EnergyItem {
        public override void SafeSetDefault(ref int maxEnergy) {
            maxEnergy = 100000;
            Item.width = 30;
            Item.height = 30;
            Item.consumable = false;
            Item.useStyle = 4;
        }
    }
}