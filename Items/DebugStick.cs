using Terraria.ModLoader;

namespace TerraEnergy.Items {
    class DebugStick : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Debug Stick");
            Tooltip.SetDefault("Totally not a minecraft reference" + "\n" +
                "Only those that worthy can use it");
        }

        public override void SetDefaults() {
            item.width = 16;
            item.height = 16;
            item.rare = -13;
        }
    }
}
