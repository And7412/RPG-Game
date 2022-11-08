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

        private readonly List<string> _itemIds = new List<string>();

        public Inventory() { }

        public void AddItems(ItemConfig item, int count)
        {
            _itemIds.Add(item.Id);

            var section = _sections.FirstOrDefault(x => x.slot == item.InventorySlot);

            if (section == null)
                throw new ArgumentException($"Cant find section {item.InventorySlot}");

            section.AddItems(item, count);
        }

        public void RemoveItems(ItemConfig item, int count)
        {
            if (_itemIds.Contains(item.Id) == false)
                throw new ArgumentException($"Inventory has no item {item.Id}");

            //TODO
        }
    }

    public interface IInventoryRead
    {

    }
}

