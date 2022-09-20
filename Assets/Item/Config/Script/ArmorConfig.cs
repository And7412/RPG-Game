﻿using UnityEngine;

namespace RPG.Item
{
    [CreateAssetMenu(fileName = "ArmorConfig", menuName = "RPG/ItemConfig/Armor", order = 0)]
    public class ArmorConfig : EquipableItemConfig
    {
        [SerializeField] private int _additionalHealth;
        public int AddedStat => _additionalHealth;
        public override InventorySlot InventorySlot => InventorySlot.Armor;
    }
}