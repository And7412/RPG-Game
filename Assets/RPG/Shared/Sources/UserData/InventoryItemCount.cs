using System;

namespace RPG.Shared.UserData
{
    [Serializable]
    public class InventoryItemCount
    {
        public string Id { get; set; }
        public int Count { get; set; }
    }
}

