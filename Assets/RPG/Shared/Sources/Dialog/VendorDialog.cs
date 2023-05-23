using System;
using RPG.Metagame.InventorySystem;
using RPG.Metagame.InventorySystem.View;
using RPG.Shared.Dialog;
using UnityEngine;

namespace RPG.GameMap.MarketSystem
{
    public class VendorDialog : Dialog<TradeDialogArgs, TradeDialogResult>
    {
        [SerializeField] private StatPanel _playerMoneyText;
        [SerializeField] private StatPanel _vendorMoneyText;
        [SerializeField] private InventoryView _vendorInventory;
        [SerializeField] private InventoryView _playerInventory;
        private Money _vMoney;
        private Money _pMoney;

        public event Action<TradeDialogResult> Closed;

        protected override void OnOpen(TradeDialogArgs args)
        {
            _pMoney = new Money(args.PlayerMoney);
            _vMoney = new Money(args.VendorMoney);
            _playerMoneyText.Initialized(_pMoney.Value.Value);
            _vendorMoneyText.Initialized(_vMoney.Value.Value);
            _vendorInventory.Initialize(args.VendorInventory);
            _vendorInventory.Show();
            _playerInventory.Initialize(args.PlayerInventory);
            _playerInventory.Show();
        }
    }

    public class TradeDialogArgs : DialogArgs
    {
        public int PlayerMoney { get; }
        public IInventoryRead PlayerInventory { get; }
        public IInventoryRead VendorInventory { get; }
        public int VendorMoney { get; }

        public TradeDialogArgs (int PMoney,int VMoney, IInventoryRead playerInventory, IInventoryRead vendorInventory)
        {
            VendorInventory = vendorInventory;
            PlayerMoney = PMoney;
            VendorMoney = VMoney;
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
