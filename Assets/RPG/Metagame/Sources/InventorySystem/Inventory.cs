using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Metagame.InventorySystem
{
    [Serializable]
    public class Inventory : IInventoryRead
    {
        [SerializeField] private List<InventoryCell> _weapons;
        [SerializeField] private List<InventoryCell> _armors;
        [SerializeField] private List<InventoryCell> _consumables;
        [SerializeField] private List<InventoryCell> _materials;
        [SerializeField] private List<InventoryCell> _misc;
        [SerializeField] private List<InventoryCell> _quest;

        public IReadOnlyList<InventoryCell> Weapons => _weapons;
        public IReadOnlyList<InventoryCell> Armors => _armors;
        public IReadOnlyList<InventoryCell> Consumables => _consumables;
        public IReadOnlyList<InventoryCell> Materials => _materials;
        public IReadOnlyList<InventoryCell> Misc => _misc;
        public IReadOnlyList<InventoryCell> Quest => _quest;

        private readonly List<string> _itemIds = new List<string>();

        public Inventory() { }

        public void AddItem(ItemConfig item)
        {
            _itemIds.Add(item.Id);

            switch (item.InventorySlot)
            {
                default:
                    throw new InvalidCastException("Unknown item slot type");
                case InventorySlot.Weapon:
//                    _weapons.Add(item as InventoryCell); //TODO
                    break;
                //TODO fill
            }

            var type = item.GetType();
        }

        public void RemoveItem(ItemConfig item)
        {
            if (_itemIds.Contains(item.Id) == false)
                throw new ArgumentException($"Inventory has no item {item.Id}");


        }
    }

    public interface IInventoryRead
    {
        IReadOnlyList<InventoryCell> Weapons { get; }
        IReadOnlyList<InventoryCell> Armors { get; }
    }
}

