using TerraEnergy.EnergyAPI;

namespace TerraEnergy.UI.Elements {
    public class FuelCore : EnergyCore {
        public FuelCore(int maxEnergy) : base(maxEnergy) {
        }

        public override int ConsumeEnergy(int energyToRemove = 1) {
            if (currentEnergy < 0) {
                return 0;
            }
            currentEnergy--;
            return 1;
        }
    }
}
