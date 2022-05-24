using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.UI;

namespace TerraEnergy.Content.Gui.Elements {
    public class GuiChargingSlot : InputOutputSlot {
        private StorageEntity storageEntity;
        private readonly int maxTransferRate;

        public GuiChargingSlot(Ref<Item> boundSlot, Texture2D slotTexture, StorageEntity storageEntity, int maxTransferRate) : base(boundSlot, slotTexture) {
            this.storageEntity = storageEntity;
            this.maxTransferRate = maxTransferRate;
        }

        public override void Update(GameTime gameTime) {
            ModItem modItem = item?.ModItem;
            if (modItem is EnergyItem energyItem) {
                if (!energyItem.isFull()) {
                    energyItem.AddEnergy(storageEntity.energy.ConsumeEnergy(maxTransferRate));
                }
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            base.DrawSelf(spriteBatch);
            CalculatedStyle innerDim = GetInnerDimensions();
            Vector2 position = new Vector2(innerDim.X - 5, innerDim.Y - 15);
            ModItem modItem = item?.ModItem;
            if (modItem != null) {
                if (modItem is EnergyItem) {
                    EnergyItem energyItem = modItem as EnergyItem;
                    if (energyItem.isFull()) {
                        spriteBatch.DrawString(FontAssets.MouseText.Value, "Full!", position, Color.White);
                    }
                    else {
                        spriteBatch.DrawString(FontAssets.MouseText.Value, "Charging", position, Color.White);
                    }
                }
                else {
                    spriteBatch.DrawString(FontAssets.MouseText.Value, "Can't charge", position, Color.White);
                }
            }
        }
    }
}
