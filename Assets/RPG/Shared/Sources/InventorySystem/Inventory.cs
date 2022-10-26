using RPG.Shared.InventorySystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Shared.InventorySystem
{
    [CreateAssetMenu(menuName = "RPG/Inventory")]
    public class Inventory : ScriptableObject, IInventoryRead
    {
        [SerializeField] private List<InventoryCell> _weapons;
        [SerializeField] private List<InventoryCell> _armors;

        private readonly List<string> _itemIds = new List<string>();

        public IReadOnlyList<InventoryCell> Weapons => _weapons;
        public IReadOnlyList<InventoryCell> Armors => _armors;

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

