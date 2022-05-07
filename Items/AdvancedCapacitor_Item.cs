using TerraEnergy.Tiles.FunctionalTiles;
using Terraria.ModLoader;

namespace TerraEnergy.Items {
    class AdvancedCapacitor_Item : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Advanced TE capacitor");
            Tooltip.SetDefault("An advanced terra energy capacitor");
        }

        public override void SetDefaults() {
            Item.width = 32;
            Item.height = 48;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.autoReuse = true;
            Item.createTile = ModContent.TileType<AdvancedCapacitor>();
        }
    }
}
