using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Metagame.InventorySystem
{
    public class InventorySection
    {
        [SerializeField] private List<InventoryCell> _cells;
        public IReadOnlyList<InventoryCell> Cells => _cells;
        public InventorySlot slot { get; }
        public InventorySection(InventorySlot inventorySlot)
        {
            slot = inventorySlot;
        }
        public void Add(ItemConfig item,int count)
        {
            InventoryCell
        }
        
    }
}
