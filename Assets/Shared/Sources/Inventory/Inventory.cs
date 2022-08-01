using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Item;
using UnityEngine;

namespace RPG.InventorySystem
{
    public class Inventory : ScriptableObject
    {
        [SerializeField] private List<WeaponConfig> _weapons;
        [SerializeField] private List<ArmorConfig> _armors;

        private readonly List<string> _itemIds = new List<string>();

        public IReadOnlyList<WeaponConfig> Weapons => _weapons;
        public IReadOnlyList<ArmorConfig> Armors => _armors;

        public void AddItem(ItemConfig item)
        {
            _itemIds.Add(item.Id);

            switch (item.InventorySlot)
            {
                default:
                    throw new InvalidCastException("Unknown item slot type");
                case InventorySlot.Weapon:
                    _weapons.Add(item as WeaponConfig);
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
}

