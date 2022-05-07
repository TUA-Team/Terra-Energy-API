using TerraEnergy.Tiles.FunctionalTiles;
using Terraria.ModLoader;

namespace TerraEnergy.Items {
    class TerraFurnace_Item : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Terra Furnace");
            Tooltip.SetDefault("The furnace you want to use!");
        }

        public override void SetDefaults() {
            Item.width = 60;
            Item.height = 42;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.autoReuse = true;
            Item.createTile = ModContent.TileType<TerraFurnace>();
        }

    }
}
