using RPG.Metagame.InventorySystem;
using UnityEngine;

namespace RPG.GameMap.Shop
{
    [CreateAssetMenu(fileName = "Vendor config", menuName = "RPG/VendorConfig")]
    public class VendorConfig : ScriptableObject
    {
        [SerializeField] private int _defaultDefaultMoneyValue = 100;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private string _name;

        public string Name => _name;

        public Inventory Inventory => _inventory;
        public int DefaultMoneyValue => _defaultDefaultMoneyValue;
    }
}

