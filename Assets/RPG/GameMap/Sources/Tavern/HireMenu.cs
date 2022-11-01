using RPG.GameMap.Tavern;
using RPG.Metagame.Player;
using RPG.Shared.Dialog;
using System;
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
        [SerializeField] private string _confirmText;
        [SerializeField] private ConfirmDialog _confirmDialog;
        [SerializeField] private string _NoMoneyText;

        private TavernHeroConfig _current;

        public event Action<HireMenuResult> Closed;

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


        private void OnHireButtonClicked()
        {
            if (_player.Money.IsEnough(_current.Price))
            {
                //$"Хотите ли вы приобрести героя {heroName} за {price} монет? 
                // У вас {n} монет"
                var args = new DialogConfirmArgs(_confirmText);
                _yesNoDialog.Closed += Hire;
                _yesNoDialog.Open(args);
            }
            else
            {
                _confirmDialog.Closed += OnNoMoneyConfirm;
                var args = new DialogConfirmArgs(_NoMoneyText);
                _confirmDialog.Open(args);
            }
        }

        private void OnNoMoneyConfirm(DialogResult result)
        {
            _confirmDialog.Closed -= OnNoMoneyConfirm;

            Close(new HireMenuResult(_current, false));
        }

        private void OnCancelButtonClicked()
        {
            Close(new HireMenuResult(_current, false));
        }

        private void Hire(DialogConfirmResult confirm)
        {
            _yesNoDialog.Closed -= Hire;
            Close(new HireMenuResult(_current, confirm.Confirm));
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

