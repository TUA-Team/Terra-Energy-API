using Terraria.ModLoader.IO;

namespace TerraEnergy.Common {
    public sealed class EnergyContainer {
        public int EnergyLevel { get; private set; }

        public int MaxEnergyLevel { get; private set; }


        public EnergyContainer(int v) {
            MaxEnergyLevel = v;
        }


        public void AddEnergy(int energyToAdd) {
            EnergyLevel += energyToAdd;
            if (EnergyLevel >= MaxEnergyLevel) {
                EnergyLevel = MaxEnergyLevel;
            }
        }

        public int ConsumeEnergy(int energyToRemove) {
            if (EnergyLevel - energyToRemove < 0) {
                int leftover = EnergyLevel;
                EnergyLevel = 0;
                return leftover;
            }
            EnergyLevel -= energyToRemove;
            return energyToRemove;
        }

        public void SetMaxEnergyLevel(int i) {
            MaxEnergyLevel = i;
        }


        public bool IsFull => EnergyLevel == MaxEnergyLevel;


        internal sealed class EnergyContainerSerializer : TagSerializer<EnergyContainer, TagCompound> {
            public override EnergyContainer Deserialize(TagCompound tag) {
                int energy = tag.GetInt(nameof(EnergyLevel));
                int max = tag.GetInt(nameof(MaxEnergyLevel));

                var ec = new EnergyContainer(max);
                ec.EnergyLevel = energy;

                return ec;
            }

            public override TagCompound Serialize(EnergyContainer value) {
                return new TagCompound {
                    {nameof(EnergyLevel), value.EnergyLevel},
                    {nameof(MaxEnergyLevel), value.MaxEnergyLevel}
                };
            }
        }
    }
}
