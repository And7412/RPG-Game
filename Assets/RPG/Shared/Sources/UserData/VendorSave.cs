using System;
namespace RPG.Shared.UserData
{
    [Serializable]
    public class VendorSave
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public InventoryItemCount[] Inventory { get; set; }
    }
}