using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;

namespace TerraEnergy.UI.Elements {
    class FuelSlot : InputOutputSlot {
        private FuelCore _energyCore;

        public FuelSlot(Ref<Item> boundSlot, Texture2D slotTexture, FuelCore energyCore) : base(boundSlot, slotTexture) {
            _energyCore = energyCore;
            CalculatedStyle s = GetInnerDimensions();
            currentSlotVector = new Vector2(s.X, s.Y);
        }

        public override void Update(GameTime gameTime) {
            if (!IsEmpty && !_energyCore.isFull()) {

                ManipulateCurrentStack(-1);
                _energyCore.addEnergy(1);
            }
        }
    }
}
