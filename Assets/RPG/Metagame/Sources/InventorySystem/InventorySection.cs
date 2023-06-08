using Core.Patterns.ServiceLocator;
using RPG.Shared.UserData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPG.Metagame.InventorySystem
{
    public class InventorySection:IInventorySectionRead
    {
        private readonly List<InventoryCell> _cells = new List<InventoryCell>();
        public IReadOnlyList<IInventoryCell> Cells => _cells;
        public InventorySlotType Slot { get; }
        public string currentObject { get; private set; }
        

        //TODO Create constructor from inventory section config
        //TODO Create constructor from slot type & items ienumerable
        public InventorySection(InventoryItemCountData[] inventorySlots , InventorySlotType slotType)
        {
            Slot = slotType;
            foreach(var inventorySlot in inventorySlots)
            {
                ServiceLocator.Instance.GetService<UserSaveSystem>();
            }
        }
        public InventorySection(InventorySectionConfig inventorySectionConfig)
        {
            Slot = inventorySectionConfig.Slot;
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
    public interface IInventorySectionRead
    {
        IReadOnlyList<IInventoryCell> Cells { get; }
        InventorySlotType Slot { get; }
    }
}
