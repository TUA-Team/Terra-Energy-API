using Terraria.ModLoader;

namespace TerraEnergy.Content.Capacitors.Items;

public sealed class BasicCapacitorItem : ModItem {
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Basic Capacitor");
        Tooltip.SetDefault("A basic terra energy capacitor");
    }

    public override void SetDefaults() {
        Item.width = 32;
        Item.height = 48;
        Item.maxStack = 99;
        Item.consumable = true;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 10;
        Item.useStyle = 1;
        Item.autoReuse = true;
        Item.createTile = ModContent.TileType<Tiles.BasicCapacitor>();
    }
}
