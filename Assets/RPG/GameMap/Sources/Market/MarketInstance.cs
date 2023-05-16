using RPG.Metagame.Player;
using RPG.Shared;
using RPG.Shared.Animations;
using RPG.Shared.SystemData;
using RPG.Shared.UserData;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.GameMap.MarketSystem
{
    public class MarketInstance : MonoBehaviour
    {
        [SerializeField] private VendorsDataBase _vendorsDataBase;
        [SerializeField] private ShopIcon[] _shopButtons;
        [SerializeField] private PointClickHandler _mapButton;
        [SerializeField] private BoolAnimator _boolAnimator;
        [SerializeField] private Button _exitButton;

        public ISavable<VendorsData> Save => _model;
        private Market _model;

        private Shop _currentOpenedShop;

        public void Initialize(IPlayerTrade player)
        {
            _mapButton.Clicked += MapButtonOnClicked;
            _exitButton.onClick.AddListener(OnExitClicked);
            _model = new Market(_vendorsDataBase);
            
            foreach (var shopButton in _shopButtons)
            {
                var vendor = _model.GetVendorByID(shopButton.Shop.Id);
                shopButton.Shop.Initialize(player, vendor);
                shopButton.ShopOpened += OnShopOpened;
            }
        }

        private void OnShopOpened(Shop obj)
        {
            _currentOpenedShop = obj;
        }

        private void OnExitClicked()
        {
            _boolAnimator.Hide();
        }

        private void MapButtonOnClicked()
        {
            _boolAnimator.Show();
        }

        private void OnDestroy()
        {
            _mapButton.Clicked -= MapButtonOnClicked;
            
            foreach (var shopButton in _shopButtons)
            {
                shopButton.ShopOpened -= OnShopOpened;
            }
        }
    }
}

