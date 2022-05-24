using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TerraEnergy.Items;

public class RodOfLinking : ModItem {
    private int _storedEntityID;
    private Point16 currentStockedEntityLocation;

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Rod of Linking");
        Tooltip.SetDefault("Link a capacitor to something\n" + 
            "Left click on a linkable\n" +
            "Right click on a capacitor\n");
    }

    public override void SetDefaults() {
        Item.width = 34;
        Item.height = 34;
        Item.useStyle = 4;
        Item.consumable = false;
    }

    public void SaveLinkableEntityLocation<T>(T entity) where T : TileEntity {
        _storedEntityID = entity.ID;
    }

    public TileEntity GetStoredEntityType() {
        return TileEntity.ByID[_storedEntityID];
    }

    public int GetEntity() {
        return _storedEntityID;
    }
}
