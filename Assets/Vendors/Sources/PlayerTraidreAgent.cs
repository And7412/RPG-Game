using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.InventorySystem;
using RPG.Vendors;
using RPG.PlayerSystem;
namespace RPG.TradeSystem
{
    public class PlayerTraidreAgent : MonoBehaviour
    {
        [SerializeField] private Vendor _vendor;
        [SerializeField] private Inventory _playerInvetory;
        [SerializeField] private VendorDialog _vendorDialog;
        private PlayerMoney _money;

        private void Awake()
        {
            _vendor.GiveInventoy += GiveInventoy;            
        }
        private void GiveInventoy(Inventory inventoyVendor)
        {
            var args = new VendorDialogArgs(_money.Value, _playerInvetory, inventoyVendor);
            _vendorDialog.Open(args);
        }
    }
}
