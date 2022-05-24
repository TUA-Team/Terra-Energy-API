using TerraEnergy.Common;
using TerraEnergy.Content.Capacitors.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TerraEnergy.Content.Capacitors.TileEntities {
    // TODO: netsend is server-side, will have to write a modpacket that syncs client-side interfacing
    public sealed class BasicCapacitorTE : ModTileEntity {
        public EnergyContainer energyContainer = new EnergyContainer(1_000_000);

        
        public override bool IsTileValidForEntity(int x, int y) {
            Tile tile = Main.tile[x, y];

            return tile.HasTile && tile.TileType == ModContent.TileType<BasicCapacitor>();
        }

        public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alternate) {
            // TODO: send data to server
            
            return Place(i, j);
        }


        public override void SaveData(TagCompound tag) {
            tag.Set(nameof(energyContainer), energyContainer);
        }

        public override void LoadData(TagCompound tag) {
            energyContainer = tag.Get<EnergyContainer>(nameof(energyContainer));
        }
    }
}
