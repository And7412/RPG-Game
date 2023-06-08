using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Metagame.InventorySystem
{

    [CreateAssetMenu(fileName = "InventoryConfig", menuName = "RPG/Inventory", order = 0)]
    public class InventoryConfig : ScriptableObject
    {
        [SerializeField] private InventorySection _weaponSection;
        [SerializeField] private InventorySection _armorSection;
        [SerializeField] private InventorySection _consumeSection;
        [SerializeField] private InventorySection _miscSection;
        [SerializeField] private InventorySection _questSection;

        public IInventorySectionRead WeaponSection => _weaponSection;
        public IInventorySectionRead ArmorSection => _armorSection;
        public IInventorySectionRead ConsumeSection => _consumeSection;
        public IInventorySectionRead MiscSection => _miscSection;
        public IInventorySectionRead QuestSection => _questSection;
    }
}
