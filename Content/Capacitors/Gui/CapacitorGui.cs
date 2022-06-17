using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using TerraEnergy.Common;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace TerraEnergy.Content.Capacitors.Gui {
    public sealed class CapacitorGui : UIState {
        private const int TEX_WIDTH = 386;
        private const int TEX_HEIGHT = 28;


        private EnergyContainer energy;

        private Asset<Texture2D> energyBarFilledTex;

        private UIPanel panel;
        private UIImage energyBar;


        public CapacitorGui(EnergyContainer energy) {
            this.energy = energy;
        }


        public override void OnInitialize() {
            energyBarFilledTex = TerraEnergy.GetTexture("EnergyBarFilled");


            panel = new();

            panel.Width.Set(410, 0);
            panel.Height.Set(200, 0);

            panel.Left.Set(Main.screenWidth / 2 - 200, 0);
            panel.Top.Set(Main.screenHeight / 2 - 100, 0);

            Append(panel);


            energyBar = new(TerraEnergy.GetTexture("EnergyBar"));

            energyBar.Width.Set(TEX_WIDTH, 0);
            energyBar.Height.Set(TEX_HEIGHT, 0);

            energyBar.HAlign = 0.5f;
            energyBar.VAlign = 0.95f;

            panel.Append(energyBar);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            base.DrawSelf(spriteBatch);


            Rectangle hitbox = energyBar.GetInnerDimensions().ToRectangle();

            float percent = energy.EnergyLevel / energy.MaxEnergyLevel;
            Rectangle sourceRectangle = new(0, 0, (int)(TEX_WIDTH * percent), TEX_HEIGHT);

            spriteBatch.Draw(energyBarFilledTex.Value, new Vector2(hitbox.X, hitbox.Y), sourceRectangle, Color.White);
        }
    }
}
