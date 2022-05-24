using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace TerraEnergy {
    public class TerraEnergy : Mod
	{
        public static TerraEnergy Instance => ModContent.GetInstance<TerraEnergy>();

        public static Asset<Texture2D> GetTexture(string path) {
            return ModContent.Request<Texture2D>("TerraEnergy/Textures/" + path);
        }
    }
}