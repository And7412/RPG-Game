using System;
using RPG.Metagame.InventorySystem;

namespace RPG.Shared.UserData
{
    [Serializable]
    public class InventoryItemCountData
    {
        public string Id { get; set; }
        public int Count { get; set; }

        public InventoryItemCountData(IInventoryCell cell)
        {
            Id = cell.Config.Id;
            Count = cell.Amount;
        }
    }
}

