using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraEnergy.Tiles;
using TerraEnergy.Tiles.FunctionalTiles;
using TerraEnergy.EnergyAPI;
using TerraEnergy.Interface;
using TerraEnergy.UI.Elements;
using TerraEnergy.Content.Capacitors.Tiles;
using TerraEnergy.Content.Capacitors;

namespace TerraEnergy.TileEntities {

    class EnergyCollectorTE : StorageEntity, ITECapacitorLinkable
    {
        private readonly int drainRange = 50;
        private int maxEnergy = 100000;
        private BaseCapacitorTE boundCapacitor;

        public override void LoadEntity(TagCompound tag)
        {
            maxEnergy = 100000;
            energy = new EnergyCore(maxEnergy);
  
        }

        public void LinkToCapacitor(BaseCapacitorTE capacitor)
        {
            boundCapacitor = capacitor;
        }

        public override void Update()
        {
            int i = Position.X + Main.rand.Next(-drainRange, drainRange);
            int j = Position.Y + Main.rand.Next(-drainRange, drainRange);

            Tile tile = Main.tile[i, j];

            if (energy == null)
            {
                energy = new EnergyCore(maxEnergy);
            }

            if (boundCapacitor != null)
            {
                boundCapacitor.energy.addEnergy(energy.ConsumeEnergy(boundCapacitor.maxTransferRate));
            }

            if (tile != null && tile.TileType != ModContent.TileType<EnergyCollector>() || tile.TileType != ModContent.TileType<BasicCapacitor>() || tile.TileType != ModContent.TileType<TerraWaste>() || tile.TileType != ModContent.TileType<TerraFurnace>() && !energy.isFull())
            {
                if (Main.tile[i, j].TileType == TileID.LunarOre)
                {
                    energy.addEnergy(50);
                    //Main.tile[i, j].type = (ushort)ModContent.TileType<TerraWaste>();
                }

                if (Main.tile[i, j].HasTile && Main.tile[i, j].TileType != (ushort)ModContent.TileType<TerraWaste>())
                {

                    energy.addEnergy(5);
                    if (Main.rand.Next(0, 1000) == 5)
                    {
                        //Main.tile[i, j].type = (ushort)ModContent.TileType<TerraWaste>();
                    }
                }
            }
        }

        public override bool IsTileValidForEntity(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            return tile.HasTile && tile.TileType == ModContent.TileType<EnergyCollector>() && tile.TileFrameX == 0 && tile.TileFrameY == 0;
        }

        public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alternate)
        {
            return Place(i - 1, j - 2);
        }
    }
}
