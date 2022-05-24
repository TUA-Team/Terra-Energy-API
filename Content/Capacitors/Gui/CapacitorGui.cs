using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using TerraEnergy.Common;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace TerraEnergy.Content.Capacitors.Gui {
    public sealed class CapacitorGui : UIState {
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

            panel.Width.Set(400, 0);
            panel.Height.Set(200, 0);

            panel.Top.Set(Main.screenHeight / 2 - 100, 0);
            panel.Left.Set(Main.screenWidth / 2 - 200, 0);

            Append(panel);


            energyBar = new(TerraEnergy.GetTexture("EnergyBar"));

            energyBar.Height.Set(28, 0);
            energyBar.Width.Set(386, 0);

            energyBar.VAlign = 0.95f;
            energyBar.HAlign = 0.5f;

            panel.Append(energyBar);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            base.DrawSelf(spriteBatch);


            Rectangle hitbox = energyBar.GetInnerDimensions().ToRectangle();

            float percent = energy.EnergyLevel / energy.MaxEnergyLevel;
            Rectangle sourceRectangle = new Rectangle(0, 0, (int)(386 * percent), 28);

            spriteBatch.Draw(energyBarFilledTex.Value, new Vector2(hitbox.X, hitbox.Y), sourceRectangle, Color.White);
        }

        public override void Update(GameTime gameTime) {
            if (!Main.playerInventory) {
                ModContent.GetInstance<CapacitorGuiSystem>().userInterface.SetState(null);
            }
        }
    }
}
