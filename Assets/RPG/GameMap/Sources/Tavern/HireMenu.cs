using RPG.Metagame.Heroes.Player;
using RPG.Shared.Dialog;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace RPG.GameMap.TavernSystem
{
    public class HireMenu :Dialog<HireMenuArgs, HireMenuResult>
    {
        [SerializeField] private Image _heroIconImage;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private Button _hireButton;
        [SerializeField] private Button _cancelButton;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private YesNoDialog _yesNoDialog;
        [SerializeField] private ConfirmDialog _confirmDialog;

        [Header("Formats")]
        [SerializeField] private string _noMoneyTextFormat = "У вас {0} монет";
        [SerializeField] private string _confirmTextFormat = "Хотите ли вы приобрести героя {0} за {1} монет?";

        private TavernHeroConfig _current;
        private IPlayerTrade _player;

        protected override void OnOpen(HireMenuArgs args)
        {
            _hireButton.onClick.AddListener(OnHireButtonClicked);
            _cancelButton.onClick.AddListener(OnCancelButtonClicked);
            _current = args.HeroConfig;
            _priceText.text = _current.Price.ToString();
            _player = args.Player;

            ShowHero(_current);
        }

        protected override void OnClose(HireMenuResult args)
        {
            _hireButton.onClick.RemoveListener(OnHireButtonClicked);
            _cancelButton.onClick.RemoveListener(OnCancelButtonClicked);
        }


        private async void OnHireButtonClicked()
        {
            if (_player.Money.IsEnough(_current.Price))
            {
                var confirmText = string.Format(_confirmTextFormat, _current.Name, _current.Price);
                var args = new DialogConfirmArgs(confirmText);
                var confirmResult = await _yesNoDialog.Run(args);
                Hire(confirmResult);
            }
            else
            {
                var noMoneyText = string.Format(_noMoneyTextFormat, _player.Money.Value);
                var args = new DialogConfirmArgs(noMoneyText);
                var confirmResult = await _confirmDialog.Run(args);
                OnNoMoneyConfirm(confirmResult);
            }
        }

        private void OnNoMoneyConfirm(DialogResult result)
        {
            SetResult(new HireMenuResult(_current, false));
        }

        private void OnCancelButtonClicked()
        {
            SetResult(new HireMenuResult(_current, false));
        }

        private void Hire(DialogConfirmResult confirm)
        {
            SetResult(new HireMenuResult(_current, confirm.Confirm));
        }

        private void ShowHero(TavernHeroConfig config)
        {
            _current = config;
            _heroIconImage.sprite = config.Icon;
            _descriptionText.text = config.Description;
        }
    }

    public class HireMenuArgs : DialogArgs
    {
        public IPlayerTrade Player { get; }
        public TavernHeroConfig HeroConfig { get; }

        public HireMenuArgs(TavernHeroConfig heroConfig, IPlayerTrade player)
        {
            HeroConfig = heroConfig;
            Player = player;
        }
    }

    public class HireMenuResult : DialogResult
    {
        public bool Hired { get; }
        private TavernHeroConfig HeroConfig { get; }

        public HireMenuResult(TavernHeroConfig heroConfig, bool hired)
        {
            HeroConfig = heroConfig;
            Hired = hired;
        }
    }

}

