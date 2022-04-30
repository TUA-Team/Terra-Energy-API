using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;

namespace TUA.Utilities {
    public static class UIManager
    {
        private static UserInterface machineInterface;
        // private static UserInterface CapacitorInterface;

        public static void InitAll()
        {
            machineInterface = new UserInterface();
            // CapacitorInterface = new UserInterface();
        }

        public static void UpdateUI(GameTime gameTime)
        {
            if (machineInterface != null && machineInterface.IsVisible)
            {
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
