using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TerraEnergy.Tiles {
    public abstract class CapacitorTile : ModTile {
        public int maxEnergyStorage;

        public override void SetStaticDefaults() {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.Origin = new Point16(0, 0);
        }
    }

}