using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TerraEnergy.Common;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace TerraEnergy.Content.Capacitors.Gui {
    public sealed class CapacitorGuiSystem : ModSystem {
        public CapacitorGui gui;

        public UserInterface userInterface;


        public override void Load() {
            if (Main.dedServ)
                return;

            userInterface = new UserInterface();
        }

        public override void UpdateUI(GameTime gameTime) {
            userInterface.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
            int index = layers.FindIndex(x => x.Name == "Vanilla: Inventory");

            if (index != -1) {
                layers.Insert(index + 1, new LegacyGameInterfaceLayer("TerraEnergy: Capacitor", () => {
                    userInterface.Draw(Main.spriteBatch, new GameTime());
                    return true;
                }, InterfaceScaleType.UI));
            }
        }


        public void OpenGui(EnergyContainer container) {
            Main.playerInventory = true;

            if (container == null) {
                Main.NewText("open gui: null container");
            }

            gui = new CapacitorGui(container);
            gui.Activate();

            userInterface.SetState(gui);
        }
    }
}
