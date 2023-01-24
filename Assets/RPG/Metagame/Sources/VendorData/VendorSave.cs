using System;
namespace RPG.Shared
{
    [Serializable]
    public class VendorSave
    {
        public string name { get; set; }
        public int Money { get; set; }
        public InventoryItemCount Inventory { get; set; }
        [Serializable]
        public class InventoryItemCount
        {
            public string Id { get; set; }
            public int Count { get; set; }
        }
    }
}