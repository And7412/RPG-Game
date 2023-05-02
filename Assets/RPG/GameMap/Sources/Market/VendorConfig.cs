using RPG.Metagame.InventorySystem;
using RPG.Shared;
using UnityEngine;

namespace RPG.GameMap.MarketSystem
{
    [CreateAssetMenu(fileName = "Vendor config", menuName = "RPG/VendorConfig")]
    public class VendorConfig : ScriptableObject
    {
        [SerializeField] private int _defaultDefaultMoneyValue = 100;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private string _id;
        [SerializeField] private string _name;

        private string _resultId;

        public string Name => _name;
        public string Id => _resultId;

        public Inventory Inventory => _inventory;
        public int DefaultMoneyValue => _defaultDefaultMoneyValue;

        private void OnValidate()
        {
            _resultId = IdCreator.GetVendorId(_id);
        }
    }
}

