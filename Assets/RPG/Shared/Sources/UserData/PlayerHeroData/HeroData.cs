using System;

namespace RPG.Shared.UserData.HeroSave
{
    [Serializable]
    public class HeroData
    {
        public HeroLevelData LevelData = new HeroLevelData();
        public InventoryData InventoryData = new InventoryData();
        public HeroAttributesData Attributes { get; set; } = new HeroAttributesData();
        public float CurrentHealthPercent { get; set; }
        public float CurrentStaminaPercent { get; set; }
    }
}