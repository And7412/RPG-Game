using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPG.Metagame.InventorySystem
{
    [Serializable]
    public class InventorySection
    {
        [SerializeField] private List<InventoryCell> _cells = new List<InventoryCell>();
        public IReadOnlyList<InventoryCell> Cells => _cells;
        public InventorySlot slot { get; }

        public InventorySection(InventorySlot inventorySlot)
        {
            slot = inventorySlot;
        }

        public void AddItems(ItemConfig item, int count)
        {
            var cell = _cells.FirstOrDefault(x => x.Config.Id == item.Id);

            if (cell == null)
            {
                cell = new InventoryCell(item);
                _cells.Add(cell);
            }

            for (int i = 0; i < count; i++)
            {
                var hasSpace = cell.TryAdd();
                if (!hasSpace)
                {
                    cell = new InventoryCell(item);
                    _cells.Add(cell);
                }
            }
        }
    }
}
