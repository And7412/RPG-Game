using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Shared.Dialog;
using RPG.InventorySystem;
using RPG.Item;
using System;

namespace RPG.Vendors
{
    public class VendorDialog : IDialog<VendorDialogArgs, VendorDialogResult>
    {
        public event Action<VendorDialogResult> Closed;

        public void Open(VendorDialogArgs args)
        {
            throw new NotImplementedException();
        }
    }

    public class VendorDialogArgs : DialogArgs
    {
        public int PlayerMoney { get; }
        public IInventoryRead PlayerInventory { get; }
        public IInventoryRead VendorInventory { get; }

        public VendorDialogArgs (int money, IInventoryRead playerInventory, IInventoryRead pendorInventory)
        {
            VendorInventory = pendorInventory;
            PlayerMoney = money;
            PlayerInventory = playerInventory;
        }
    }
    public class VendorDialogResult : DialogResult
    {
        public ItemTransaction[] Transactions;

        public VendorDialogResult(ItemTransaction[] transactions)
        {
            Transactions = transactions;
        }
    }
}
