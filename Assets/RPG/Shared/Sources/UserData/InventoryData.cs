using System;

namespace RPG.Shared.UserData
{
    [Serializable]
    public class InventoryData 
    {
        public int Money { get; set; }
        public InventoryItemCountData[] InventoryItems { get; set; } = new InventoryItemCountData[0];
    }
}
