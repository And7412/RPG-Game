using UnityEngine;

namespace RPG.Metagame.InventorySystem
{
    [CreateAssetMenu(fileName = "ArmorConfig", menuName = "RPG/ItemConfig/Armor", order = 0)]
    public class ArmorConfig : ItemConfig
    {
        [SerializeField] private int _additionalHealth;
        public int AddedStat => _additionalHealth;
        public override InventorySlot InventorySlot => InventorySlot.Armor;
    }
}
