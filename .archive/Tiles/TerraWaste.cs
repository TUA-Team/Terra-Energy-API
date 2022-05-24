using Microsoft.Xna.Framework;
using TerraEnergy.Items;
using Terraria;
using Terraria.ModLoader;

namespace TerraEnergy.Tiles {
    public class TerraWaste : ModTile {
        public override void SetStaticDefaults() {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            ItemDrop = ModContent.ItemType<TerraWaste_Item>();
            AddMapEntry(Color.SandyBrown);
        }
    }
}
