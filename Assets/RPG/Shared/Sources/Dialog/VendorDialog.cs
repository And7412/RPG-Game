using RPG.Metagame.Player;
using RPG.Shared.Dialog;
using RPG.Metagame.InventorySystem;
using RPG.Metagame.InventorySystem.View;
using System;
using UnityEngine;

namespace RPG.GameMap.Market
{
    public class VendorDialog : MonoBehaviour, IDialog<TradeDialogArgs, TradeDialogResult>
    {
        [SerializeField] private TextView _playerMoneyText;
        [SerializeField] private TextView _vendorMoneyText;
        [SerializeField] private InventoryView _vendorInventory;
        [SerializeField] private InventoryView _playerInventory;
        private Money _vMoney;
        private Money _pMoney;

        public event Action<TradeDialogResult> Closed;

        public void Open(TradeDialogArgs args)
        {
            _pMoney = new Money(args.PlayerMoney);
            _vMoney = new Money(args.VendorMoney);
            _pMoney.MoneyChanged += _playerMoneyText.SetText;
            _vMoney.MoneyChanged += _vendorMoneyText.SetText;
            _vendorInventory.Initialize(args.VendorInventory);
            _playerInventory.Initialize(args.PlayerInventory);
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
