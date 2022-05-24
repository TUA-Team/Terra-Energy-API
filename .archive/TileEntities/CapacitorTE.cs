using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerraEnergy.Content.Capacitors.Tiles;
using TerraEnergy.Common;
using TerraEnergy.Content.Gui;
using System.Collections.Generic;
using TerraEnergy.UI.Elements;
using Terraria.DataStructures;

namespace TerraEnergy.Content.Capacitors;

public abstract class CapacitorTE : StorageEntity {
    public EnergyCore energy;
    public int maxEnergy;

    internal int worldID => ID;

    public virtual List<GuiItemSlot> GetSlot() {
        List<GuiItemSlot> dumpList = new List<GuiItemSlot>();
        return dumpList;
    }

    public sealed override void SaveData(TagCompound tag) {
        int itemSlotId = 0;
        for (int i = 0; i < slot.Length; i++) {
            Item extraSlot = slot[i];
            tag.Add("slot" + i, extraSlot);
            itemSlotId++;
        }
        // TODO: so this is broken, `energy` is null or something
        //tag.Add("energy", energy.getCurrentEnergyLevel());
    }

    public sealed override void LoadData(TagCompound tag) {
        energy = new EnergyCore(0);
        InitializeItemSlot();
        for (int i = 0; i < slot.Length; i++) {
            Item item = tag.Get<Item>("slot" + i);
            SetAir(ref item);
            slot[i] = item;
        }
        energy.addEnergy(tag.GetAsInt("energy"));
    }

    public static byte[] CompressBytes(byte[] data) {
        MemoryStream output = new MemoryStream();
        using (var deflateStream = new DeflateStream(output, CompressionMode.Compress, false)) {
            deflateStream.Write(data, 0, data.Length);
        }
        return output.ToArray();
    }

    public static byte[] DecompressBytes(byte[] data) {
        MemoryStream input = new MemoryStream(data);
        MemoryStream output = new MemoryStream();
        using (var deflateStream = new DeflateStream(input, CompressionMode.Decompress)) {
            deflateStream.CopyTo(output);
        }
        return output.ToArray();
    }


    public override void NetSend(BinaryWriter writer) {
        TagCompound tag = new TagCompound();
        tag.Add("energy", energy.getCurrentEnergyLevel());
        tag.Add("maxEnergy", energy.getMaxEnergyLevel());
        TagIO.Write(tag, writer);
    }

    public override void NetReceive(BinaryReader reader) {
        TagCompound tag = TagIO.Read(reader);
        energy = new EnergyCore(tag.GetAsInt("maxEnergy"));
        energy.addEnergy(tag.GetAsInt("energy"));
    }

    public virtual void LoadEntity(TagCompound tag) {
    }

    public EnergyCore GetEnergy() {
        if (energy == null) {
            energy = new EnergyCore(maxEnergy);
        }
        return energy;
    }

    public int GetMaxEnergyStored() {
        if (energy == null) {
            energy = new EnergyCore(maxEnergy);
        }
        return energy.getMaxEnergyLevel();
    }

    public new int Place(int i, int j) {
        ModTileEntity modTileEntity = ConstructFromBase(this);
        modTileEntity.Position = new Point16(i, j);
        modTileEntity.ID = AssignNewID();
        modTileEntity.type = (byte)Type;
        ByID[modTileEntity.ID] = modTileEntity;
        ByPosition[modTileEntity.Position] = modTileEntity;
        energy = new EnergyCore(maxEnergy);
        return modTileEntity.ID;
    }

    public int maxTransferRate;
    public CapacitorGui CapacitorGui;
    private Item[] slot;

    public CapacitorTE() {
        slot = new Item[4];
        for (int i = 0; i < slot.Length; i++) {
            slot[i] = new Item();
            slot[i].TurnToAir();
        }
    }

    public void Activate() {
        InitializeItemSlot();
        CapacitorGui = new CapacitorGui(slot, this);
        //Main.playerInventory = true;
        //UIManager.OpenMachineUI(CapacitorUi);
    }

    public void SetAir(ref Item item) {
        if (item.Name == "Unloaded Item") {
            item.TurnToAir();
        }
    }

    public override bool IsTileValidForEntity(int x, int y) {
        Tile tile = Main.tile[x, y];
        return tile.HasTile && (tile.TileType == ModContent.TileType<BasicCapacitor>());
    }

    public override void Update() {
        if (energy == null) {
            energy = new EnergyCore(maxEnergy);
        }
    }

    public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alternate) {
        InitializeItemSlot();
        energy = new EnergyCore(maxEnergy);
        return Place(i - 1, j - 1);
    }

    private void InitializeItemSlot() {
        slot = new Item[4];
        for (int i = 0; i < slot.Length; i++) {
            slot[i] = new Item();
            slot[i].TurnToAir();
        }
    }
}
