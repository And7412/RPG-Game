using System;
namespace RPG.Shared.UserData
{
    [Serializable]
    public class VendorSave
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public InventoryItemCountData[] Inventory { get; set; }
    }
}