using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TerraEnergy.TileEntities;
using TUA.API;

namespace TerraEnergy.Tiles
{
    public class Capacitor : ModTile
    {
        public override bool Autoload(ref string name, ref string texture) {
            return false;
        }

        public int maxEnergyStorage;

        public ModTileEntity GetCapacitorEntity()
        {
            return ModContent.GetInstance<CapacitorTE>();

        }

        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.Origin = new Point16(0, 0);
        }

       

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            ModContent.GetInstance<CapacitorTE>().Kill(i, j);
        }
    }

}