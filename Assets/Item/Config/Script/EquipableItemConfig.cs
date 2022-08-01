using UnityEngine;


namespace RPG.Item
{
    public class EquipableItemConfig : ItemConfig
    {
        [SerializeField] private Rarity _rarity;
        public Rarity Rarity => _rarity;
    }
}


