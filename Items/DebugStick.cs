using Terraria.ModLoader;

namespace TerraEnergy.Items {
    class DebugStick : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Debug Stick");
            Tooltip.SetDefault("Totally not a minecraft reference" + "\n" +
                "Only those that worthy can use it");
        }

        public override void SetDefaults() {
            Item.width = 16;
            Item.height = 16;
            Item.rare = -13;
        }
    }
}
