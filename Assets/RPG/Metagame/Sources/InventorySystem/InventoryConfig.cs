using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Metagame.InventorySystem
{

    [CreateAssetMenu(fileName = "InventoryConfig", menuName = "RPG/Inventory", order = 0)]
    public class InventoryConfig : ScriptableObject
    {
        [SerializeField] private InventorySectionConfig _weaponSection = new InventorySectionConfig(InventorySlotType.Weapon);
        [SerializeField] private InventorySectionConfig _armorSection = new InventorySectionConfig(InventorySlotType.Armor);
        [SerializeField] private InventorySectionConfig _consumeSection = new InventorySectionConfig(InventorySlotType.Consume);
        [SerializeField] private InventorySectionConfig _miscSection = new InventorySectionConfig(InventorySlotType.Misc);
        [SerializeField] private InventorySectionConfig _questSection = new InventorySectionConfig(InventorySlotType.Quest);

        public InventorySectionConfig WeaponSection => _weaponSection;
        public InventorySectionConfig ArmorSection => _armorSection;
        public InventorySectionConfig ConsumeSection => _consumeSection;
        public InventorySectionConfig MiscSection => _miscSection;
        public InventorySectionConfig QuestSection => _questSection;
    }
}
