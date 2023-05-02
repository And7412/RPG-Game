using System.Collections.Generic;
using RPG.Metagame.InventorySystem;

namespace RPG.Shared
{
    public static class IdCreator
    {
        private static readonly Dictionary<InventorySlotType, string> slotPrefixes
            = new Dictionary<InventorySlotType, string>()
            {
                { InventorySlotType.Armor, "a" },
                { InventorySlotType.Weapon, "w" },
                { InventorySlotType.Consume, "c" },
                { InventorySlotType.Misc, "m" },
                { InventorySlotType.Quest, "q" }
            };
        
        private const string itemIdFormat = "i_{0}_{1}";
        private const string vendorIdFormat = "v_{0}";

        public static string GetItemId(InventorySlotType slotType, string id)
        {
            var slotPrefix = slotPrefixes[slotType];
            return string.Format(itemIdFormat, slotPrefix, id);
        }
        
        public static string GetVendorId(string id)
        {
            return string.Format(vendorIdFormat, id);
        }
    }
}

