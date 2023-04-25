using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPG.Metagame.InventorySystem
{
    [Serializable]
    public class Inventory : IInventoryRead
    {
        [SerializeField] private InventorySection _weaponSection;
        [SerializeField] private InventorySection _armorSection;
        [SerializeField] private InventorySection _consumeSection;
        [SerializeField] private InventorySection _miscSection;
        [SerializeField] private InventorySection _questSection;
        
        private InventorySection[] _sections;
        private ItemConfig[] _itemsConfig;

        public IInventorySectionRead WeaponSection => _weaponSection;
        public IInventorySectionRead ArmorSection => _armorSection;
        public IInventorySectionRead ConsumeSection => _consumeSection;
        public IInventorySectionRead MiscSection => _miscSection;
        public IInventorySectionRead QuestSection => _questSection;
        public IInventorySectionRead[] Sections => _sections;

        public Inventory()
        {
            _sections = new []
            {
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

        public InventorySection GetInventorySection(ItemConfig item)
        {
            var section = _sections.FirstOrDefault(x => x.Slot == item.InventorySlot);
            if (section == null)
                throw new ArgumentException($"Cant find section {item.InventorySlot}");
            return section;
        }
    }

    public interface IInventoryRead
    {
        IInventorySectionRead WeaponSection { get; }
        IInventorySectionRead ArmorSection { get; }
        IInventorySectionRead ConsumeSection { get; }
        IInventorySectionRead MiscSection { get; }
        IInventorySectionRead QuestSection { get; }
    }
}

