using RPG.Metagame.InventorySystem;
using UnityEngine;

namespace RPG.GameMap.Shop
{
    [CreateAssetMenu(fileName = "Vendor config", menuName = "RPG/VendorConfig")]
    public class VendorConfig : ScriptableObject
    {
        [SerializeField] private Inventory _inventory;

        public Inventory Inventory => _inventory;
    }
}

