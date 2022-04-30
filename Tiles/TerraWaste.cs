using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TerraEnergy.Tiles {
    public class TerraWaste : ModTile {
        public override void SetDefaults() {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = ModContent.ItemType<TerraWaste_Item>();
            AddMapEntry(Color.SandyBrown);
        }
    }
}
