using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Metagame.InventorySystem
{
    [Serializable]
    public class InventorySectionConfig
    {
        [SerializeField] private List<InventoryCell> _cells = new List<InventoryCell>();
        
        public IReadOnlyList<IInventoryCell> Cells => _cells;
        public InventorySlotType Slot { get; }

        public InventorySectionConfig(InventorySlotType inventorySlot)
        {
            Slot = inventorySlot;
        }
    }

}
