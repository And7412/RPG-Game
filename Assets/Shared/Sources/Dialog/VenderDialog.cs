using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Shared.Dialog;
using RPG.PlayerSystem;
namespace RPG.Vendors
{
    public class VendorDialog : IDialog<VendorDialogArgs>
    {

    }
    public class VendorDialogArgs : DialogArgs
    {
        private VendorConfig _config;
        private IPlayerTrade _playermoney;
        public VendorDialogArgs (VendorConfig config,IPlayerTrade player)
        {
            _config = config;
            _playermoney = player.Money;
        }
    }
    public class VendorDialogResult : DialogResult
    {

    }
}
