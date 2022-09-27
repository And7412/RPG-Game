using UnityEngine;

namespace RPG.Item
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "RPG/ItemConfig/Weapon", order = 0)]
    public class WeaponConfig : ItemConfig
    {
        [SerializeField] private int _additionalAttack;
        public int AddedStat => _additionalAttack;

        public override InventorySlot InventorySlot => InventorySlot.Weapon;
    }
}
