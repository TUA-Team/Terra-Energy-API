using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace TUA.Utilities {
    public sealed class UIManager : ModSystem
    {
        private static UserInterface machineInterface;
        // private static UserInterface CapacitorInterface;

        public override void Load() {
            if (Main.dedServ)
                return;

            machineInterface = new UserInterface();
        }

        public override void Unload() {
            machineInterface?.SetState(null);
            machineInterface = null;
        }

        public override void UpdateUI(GameTime gameTime) {
            if (machineInterface != null && machineInterface.IsVisible) {
                machineInterface.Update(gameTime);
            }
        }

        public static void DrawFurnace()
        {
            if (machineInterface.IsVisible && Main.playerInventory)
            {
                machineInterface.CurrentState.Draw(Main.spriteBatch); ;
            }
        }

        public static void OpenMachineUI(UIState state)
        {
            machineInterface.SetState(state);
            machineInterface.IsVisible = true;
        }

        public static void CloseMachineUI() 
        {
            machineInterface.SetState(null);
            machineInterface.IsVisible = false;
        }
    }
}
