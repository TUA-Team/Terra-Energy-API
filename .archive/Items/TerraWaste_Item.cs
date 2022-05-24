using TerraEnergy.Tiles;
using Terraria.ModLoader;

namespace TerraEnergy.Items {
    public sealed class TerraWaste_Item : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Terra Waste");
            Tooltip.SetDefault("A block where the essence was completly drained...");
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
            Item.createTile = ModContent.TileType<TerraWaste>();
        }
    }
}
