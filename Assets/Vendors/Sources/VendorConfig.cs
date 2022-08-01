using System.Collections;
using System.Collections.Generic;
using RPG.InventorySystem;
using UnityEngine;

namespace RPG.Vendors
{
    [CreateAssetMenu(fileName = "Vendor config", menuName = "RPG/VendorConfig")]
    public class VendorConfig : ScriptableObject
    {
        [SerializeField] private Inventory _inventory;
    }
}

