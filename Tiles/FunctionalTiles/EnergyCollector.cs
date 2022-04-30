using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TerraEnergy.EnergyAPI;
using TerraEnergy.Interface;
using TerraEnergy.TileEntities;
using TerraEnergy.Items;

namespace TerraEnergy.Tiles.FunctionalTiles {
    class EnergyCollector : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.Origin = new Point16(1, 2);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<EnergyCollectorTE>().Hook_AfterPlacement, -1, 0, false);
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
        }

        public override bool NewRightClick(int i, int j)
        {
            Player player = Main.player[Main.myPlayer];
            Item currentSelectedItem = player.inventory[player.selectedItem];

            Tile tile = Main.tile[i, j];

            int left = i - (tile.frameX / 18);
            int top = j - (tile.frameY / 18);

            int index = ModContent.GetInstance<EnergyCollectorTE>().Find(left, top);

            Main.NewText("X " + i + " Y " + j);

            if (index == -1)
            {
                Main.NewText("false");
                return false;
            }
            if (currentSelectedItem.type == ModContent.ItemType<TerraMeter>())
            {
                StorageEntity se = (StorageEntity)TileEntity.ByID[index];
                Main.NewText(se.GetEnergy().getCurrentEnergyLevel() + " / " + se.GetEnergy().getMaxEnergyLevel() + " TE");
            }

            if (currentSelectedItem.type == ModContent.ItemType<RodOfLinking>())
            {
                RodOfLinking it = currentSelectedItem.modItem as RodOfLinking;
                StorageEntity se = (StorageEntity)TileEntity.ByID[index];

                var TE = TileEntity.ByID[index];


                if (TE is ITECapacitorLinkable)
                {
                    it.SaveLinkableEntityLocation(TE);
                }
                
                Main.NewText("Succesfully linked to a collector, now right click on a capacitor to unlink");
            }

            return false;
        }
    }

}