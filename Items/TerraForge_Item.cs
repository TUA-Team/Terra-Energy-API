using TerraEnergy.Tiles.FunctionalTiles;
using Terraria.ModLoader;

namespace TerraEnergy.Items {
    class TerraForge_Item : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Terra Forge");
            Tooltip.SetDefault("A machine that can forge metal");
        }

        public override void SetDefaults() {

            Item.width = 96;
            Item.height = 152;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.autoReuse = true;
            Item.createTile = ModContent.TileType<TerraForge>();
        }
    }
}

