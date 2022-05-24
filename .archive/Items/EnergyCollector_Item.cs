using TerraEnergy.Tiles.FunctionalTiles;
using Terraria.ModLoader;

namespace TerraEnergy.Items {
    class EnergyCollector_Item : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Energy Collector");
            Tooltip.SetDefault("A basic terra energy collector");
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
            Item.createTile = ModContent.TileType<EnergyCollector>();
        }
    }
}