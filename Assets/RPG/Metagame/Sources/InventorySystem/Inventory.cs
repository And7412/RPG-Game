using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPG.Metagame.InventorySystem
{
    [Serializable]
    public class Inventory : IInventoryRead
    {
        [SerializeField] private InventorySection[] _sections;

        public Inventory() { }

        public void AddItems(ItemConfig item, int count)
        {

            var section = GetInventorySection(item);

            section.AddItems(item, count);
        }

        public void RemoveItems(ItemConfig item, int count)
        {
            var section = GetInventorySection(item);
            if (section == item.Id )
                throw new ArgumentException($"Inventory has no item {item.Id}");

            
        }
        public InventorySection GetInventorySection(ItemConfig item)
        {
            var section = _sections.FirstOrDefault(x => x.slot == item.InventorySlot);
            if (section == null)
                throw new ArgumentException($"Cant find section {item.InventorySlot}");
            return section;
        }
    }

    public interface IInventoryRead
    {

    }
}

