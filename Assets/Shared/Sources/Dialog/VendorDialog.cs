using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Shared.Dialog;
using RPG.InventorySystem;
using RPG.Item;
using System;

namespace RPG.Vendors
{
    public class VendorDialog : MonoBehaviour, IDialog<TradeDialogArgs, TradeDialogResult>
    {
        public event Action<TradeDialogResult> Closed;

        public void Open(TradeDialogArgs args)
        {
            
        }
    }

    public class TradeDialogArgs : DialogArgs
    {
        public int PlayerMoney { get; }
        public IInventoryRead PlayerInventory { get; }
        public IInventoryRead VendorInventory { get; }

        public TradeDialogArgs (int money, IInventoryRead playerInventory, IInventoryRead vendorInventory)
        {
            VendorInventory = vendorInventory;
            PlayerMoney = money;
            PlayerInventory = playerInventory;
        }
    }
    public class TradeDialogResult : DialogResult
    {
        public ItemTransaction[] Transactions;

        public TradeDialogResult(ItemTransaction[] transactions)
        {
            Transactions = transactions;
        }
    }
}
