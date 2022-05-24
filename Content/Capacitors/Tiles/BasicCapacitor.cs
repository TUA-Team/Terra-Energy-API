using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TerraEnergy.Content.Capacitors.TileEntities;
using TerraEnergy.Content.Capacitors.Gui;

namespace TerraEnergy.Content.Capacitors.Tiles;

public sealed class BasicCapacitor : ModTile {
    public override void SetStaticDefaults() {
        Main.tileFrameImportant[Type] = true;
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
        TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<BasicCapacitorTE>().Hook_AfterPlacement, -1, 0, false);
        TileObjectData.addTile(Type);
    }

    public override bool RightClick(int i, int j) {
        Tile tile = Main.tile[i, j];
        int left = i - tile.TileFrameX / 18;
        // We find the bottom because that's where the tile is anchored to the mouse when placing
        int bottom = j - tile.TileFrameY / 18 + 1;

        int index = ModContent.GetInstance<BasicCapacitorTE>().Find(left, bottom);

        if (index == -1) {
            Main.NewText("No capacitor TE");
            return false;
        }

        BasicCapacitorTE capacitor = (BasicCapacitorTE)TileEntity.ByID[index];

        ModContent.GetInstance<CapacitorGuiSystem>().OpenGui(capacitor.energyContainer);

        return true;

        /*Player player = Main.player[Main.myPlayer];
        Item heldItem = player.inventory[player.selectedItem];



        

        //Main.NewText("X " + i + " Y " + j);

        int index = ModContent.GetInstance<BasicCapacitorTE>().Find(left, top);

        if (index == -1) {
            Main.NewText("false");
            return false;
        }

        if (heldItem.type == ModContent.ItemType<TerraMeter>()) {
            StorageEntity se = (StorageEntity)TileEntity.ByID[index];
            Main.NewText(se.GetEnergy().getCurrentEnergyLevel() + " / " + se.GetEnergy().getMaxEnergyLevel() + " TE in this Capacitor");
            return false;
        }

        if (heldItem.ModItem is RodOfLinking rod) {
            int tileEntityID = rod.GetEntity();

            if (tileEntityID == -1) {
                Main.NewText("The rod of linking is bound to nothing");
                return false;
            }

            // TODO: highly repetitive, plus it seems a little scuffed
            BaseCapacitorTE ce = (BaseCapacitorTE)TileEntity.ByID[index];

            if (TileEntity.ByID[rod.GetStoredEntityType().type] is ITECapacitorLinkable terraEnergyCompatibleLinkable) {
                terraEnergyCompatibleLinkable.LinkToCapacitor(ce);
                Main.NewText("Succesfully linked to a capacitor, now transferring energy to it", Color.ForestGreen);
            }
            return false;
        }*/
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY) {
        Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, i * 16, 32, 48, ModContent.ItemType<Items.BasicCapacitorItem>());
        ModContent.GetInstance<BasicCapacitorTE>().Kill(i, j);
    }
}
