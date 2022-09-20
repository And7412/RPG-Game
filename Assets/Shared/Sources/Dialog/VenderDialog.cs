using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Shared.Dialog;
using RPG.InventorySystem;
namespace RPG.Vendors
{
    public class VendorDialog : IDialog<VendorDialogArgs>
    {

    }
    public class VendorDialogArgs : DialogArgs
    {
        private VendorConfig _config;
        private int _playermoney;
        private Inventory _inventory;
        public VendorDialogArgs (VendorConfig config,int money, Inventory inventory)
        {
            _config = config;
            _playermoney = money;
            _inventory = inventory;
        }
    }
    public class VendorDialogResult : DialogResult
    {

    }
}
