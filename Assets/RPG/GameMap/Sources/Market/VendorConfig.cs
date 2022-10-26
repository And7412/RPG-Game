using RPG.Shared.InventorySystem;
using UnityEngine;

namespace RPG.GameMap.Market
{
    [CreateAssetMenu(fileName = "Vendor config", menuName = "RPG/VendorConfig")]
    public class VendorConfig : ScriptableObject
    {
        [SerializeField] private Inventory _inventory;

        public Inventory Inventory => _inventory;
    }
}

