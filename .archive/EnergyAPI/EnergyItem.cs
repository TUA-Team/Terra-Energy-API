using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TerraEnergy.EnergyAPI {
    public abstract class EnergyItem : ModItem
    {
        private int maxEnergyStorage;
        private EnergyCore _energyCore;
        public int energy = 0;

        public int MaxEnergyStorage
        {
            get { return maxEnergyStorage; }
            protected set { maxEnergyStorage = value; }
        }

        public int CurrentEnergy
        {
            get => _energyCore.getCurrentEnergyLevel(); 
        }

        public sealed override void SetDefaults()
        {
            SafeSetDefault(ref maxEnergyStorage);
            _energyCore = new EnergyCore(maxEnergyStorage);
        }

        public virtual void SafeSetDefault(ref int maxEnergy)
        {

        }

        public sealed override void SaveData(TagCompound tag) {
            tag.Set("CurrentEnergy", _energyCore.getCurrentEnergyLevel());
            NewSave(ref tag);
        }

        public virtual void NewSave(ref TagCompound tag)
        {

        }

        public sealed override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("currentEnergy")) {
                _energyCore.addEnergy(tag.GetAsInt("currentEnergy"));
            }
            
            NewLoad(tag);
        }

        public virtual void NewLoad(TagCompound tag)
        {

        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine energyLine = new(Mod, "energy", _energyCore.getCurrentEnergyLevel() + " / " + _energyCore.getMaxEnergyLevel() + " TE");
            tooltips.Add(energyLine);
        }

        

        public void AddEnergy(int energy)
        {
            _energyCore.addEnergy(energy);
        }

        public bool isFull()
        {
            return _energyCore.isFull();
        }
    }
}
