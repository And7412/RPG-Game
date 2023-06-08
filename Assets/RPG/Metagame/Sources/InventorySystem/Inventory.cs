using System;
using System.Collections.Generic;
using System.Linq;
using RPG.Shared.UserData;
using UnityEngine;

namespace RPG.Metagame.InventorySystem
{
    public class Inventory : IInventoryRead
    {
        private InventorySection[] _sections;
        private ItemConfig[] _itemsConfig;
        
        public IInventorySectionRead[] Sections => _sections;
        
        public Money Money { get; private set; }

        public Inventory(InventoryConfig config)
        {
            _sections = new []
            {
                new InventorySection(config.WeaponSection),
                new InventorySection(config.ArmorSection),
                new InventorySection(config.MiscSection),
                new InventorySection(config.ConsumeSection),
                new InventorySection(config.QuestSection)
            };
        }
        
        public Inventory(InventoryData data)
        {
            _sections = new []
            {
                //TODO fill sections from inventory data
                _weaponSection = new InventorySection(InventorySlotType.Weapon),
                _armorSection = new InventorySection(InventorySlotType.Armor),
                _consumeSection = new InventorySection(InventorySlotType.Consume),
                _miscSection = new InventorySection(InventorySlotType.Misc),
                _questSection = new InventorySection(InventorySlotType.Quest)
            };
        }

        public void AddItems(ItemConfig item, int count)
        {
            var section = GetInventorySection(item);
            section.AddItems(item, count);
        }

        public void RemoveItems(ItemConfig item, int count)
        {
            var section = GetInventorySection(item);
            if (section.currentObject == item.Id)
            {
                section.RemoveItems(item ,count);
                return;
            } 

            throw new ArgumentException($"Inventory has no item {item.Id}");
        }

        //TODO bool HasItem(ItemConfig item)

        private InventorySection GetInventorySection(ItemConfig item)
        {
            var section = _sections.FirstOrDefault(x => x.Slot == item.InventorySlot);
            if (section == null)
                throw new ArgumentException($"Cant find section {item.InventorySlot}");
            return section;
        }

        public IInventorySectionRead GetReadonlyInventorySection(InventorySlotType slotType)
        {
            //TODO
        }
    }

    public interface IInventoryRead
    {
        IInventorySectionRead GetReadonlyInventorySection(InventorySlotType slotType);
        Money Money { get; }
    }
}

