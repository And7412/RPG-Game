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
        public InventorySlotType Slot { get; }
        public string currentObject { get; private set; }
        

        public InventorySection(InventorySlotType inventorySlot)
        {
            Slot = inventorySlot;
        }

        public void AddItems(ItemConfig item, int count)
        {
            var cell = GetCell(item.Id);
            
            for (int i = 0; i < count; i++)
            {
                
                var hasSpace = cell.TryAdd();
                currentObject = item.Id;
                if (!hasSpace)
                {
                    cell = new InventoryCell(item);
                    _cells.Add(cell);
                }
            }
        }
        public void RemoveItems(ItemConfig item, int count)
        {
            var cell = GetCell(item.Id);
            for (int i = 0; i < count; i++)
            {
                bool value = cell.Remove();
                if (!value)
                {
                    _cells.Remove(cell);
                    cell = GetCell(item.Id);
                }
            }
        }

        private InventoryCell GetCell(string ID)
        {
            var cell = _cells.FirstOrDefault(x => x.Config.Id == ID);

            if (cell == null)
            {
                throw new ArgumentException($"Cant find Cell {ID}");
            }

            return cell;
        }
    }
}
