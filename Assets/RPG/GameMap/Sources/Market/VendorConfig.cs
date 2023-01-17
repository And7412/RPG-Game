using RPG.Metagame.InventorySystem;
using UnityEngine;

namespace RPG.GameMap.Shop
{
    [CreateAssetMenu(fileName = "Vendor config", menuName = "RPG/VendorConfig")]
    public class VendorConfig : ScriptableObject
    {
        [SerializeField] private int _defaultDefaultMoneyValue = 100;
        [SerializeField] private Inventory _inventory;

        public Inventory Inventory => _inventory;
        public int DefaultMoneyValue => _defaultDefaultMoneyValue;
    }
}

