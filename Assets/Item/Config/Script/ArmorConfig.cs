using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Item.Config.Armor
{
    [CreateAssetMenu(fileName = "ArmorConfig", menuName = "RPG/ItemConfig/Armor", order = 0)]
    public class ArmorConfig : ScriptableObject
    {
        public TypeItem _type { get; private set; } = TypeItem.Armor;
        [SerializeField] private ReceiptType _receiptType;
        [SerializeField] private int _additionalHealth;
        public ReceiptType ReceiptType => _receiptType;
        public int AddedStat => _additionalHealth;
    }
}
