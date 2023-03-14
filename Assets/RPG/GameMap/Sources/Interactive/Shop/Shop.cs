using RPG.Metagame.Player;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.GameMap.Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private VendorConfig _vendor;
        [SerializeField] private Button _vendorButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private VendorDialog _vendorDialog;

        private IPlayerTrade _player;

        private void Awake()
        {
            _vendorButton.onClick.AddListener(OnVendorClick);
            _exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void OnExitButtonClicked()
        {
            SetActive(false);
        }

        public void Initialize(IPlayerTrade player)
        {
            _player = player;
        }

        private async void OnVendorClick()
        {
            var args = new TradeDialogArgs(_player.Money.Value,_vendor.DefaultMoneyValue, _player.Inventory, _vendor.Inventory);
            await _vendorDialog.Run(args);
        }

        public void SetActive(bool value)
        {
            _canvas.enabled = value;
        }
    }
}

