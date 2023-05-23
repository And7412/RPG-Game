using RPG.Metagame.Player;
using RPG.Shared;
using RPG.Shared.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.GameMap.MarketSystem
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private string _id;
        [SerializeField] private BoolAnimator _animator;
        [SerializeField] private Button _vendorButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private VendorDialog _vendorDialog;

        public string Id => IdCreator.GetVendorId(_id);
        public bool Opened { get; private set; }

        private IPlayerTrade _player;
        private Vendor _vendor;

        private void Awake()
        {
            _vendorButton.onClick.AddListener(OnVendorClick);
            _exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void OnExitButtonClicked()
        {
            Hide();
        }

        public void Initialize(IPlayerTrade player, Vendor vendor)
        {
            _player = player;
            _vendor = vendor;
        }

        private async void OnVendorClick()
        {
            var args = new TradeDialogArgs(_player.Money.Value.Value,_vendor.Money, _player.Inventory, _vendor.Inventory);
            await _vendorDialog.Run(args);
        }

        public void Hide()
        {
            Opened = false;
            _animator.Hide();
        }

        public void Show()
        {
            _animator.Show();
            Opened = true;
        }
    }
}

