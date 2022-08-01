using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Item.Config.Weapon
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "RPG/ItemConfig/Weapon", order = 0)]
    public class WeaponConfig : ScriptableObject
    {
        public TypeItem _type { get; private set; } = TypeItem.Weapon;
        [SerializeField] private ReceiptType _receiptType;
        [SerializeField] private int _additionalAttack;
        public ReceiptType ReceiptType => _receiptType;
        public int AddedStat => _additionalAttack;
    }
}
