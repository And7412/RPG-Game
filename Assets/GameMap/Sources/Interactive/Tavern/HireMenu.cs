using RPG.Heroes.Tavern;
using RPG.PlayerSystem;
using RPG.Shared.Dialog;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace RPG.GameMap.TavernSystem
{
    public class HireMenu : MonoBehaviour, IDialog<HireMenuArgs, HireMenuResult>
    {
        [SerializeField] private Canvas _canvas;
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

        public void Open(HireMenuArgs args)
        {
            _hireButton.onClick.AddListener(OnHireButtonClicked);
            _cancelButton.onClick.AddListener(OnCancelButtonClicked);
            _current = args.HeroConfig;
            _priceText.text = _current.Price.ToString();
            _player = args.Player;

            ShowHero(_current);
            ShowMenu(true);
        }

        public void Close(bool hired)
        {
            var result = new HireMenuResult(_current, hired);

            _hireButton.onClick.RemoveListener(OnHireButtonClicked);
            _cancelButton.onClick.RemoveListener(OnCancelButtonClicked);

            Closed?.Invoke(result);
            ShowMenu(false);
        }

        public void ShowMenu(bool value) => _canvas.enabled = value;

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
            Close(false);
        }
        private void OnCancelButtonClicked()
        {
            Close(false);
        }

        private void Hire(DialogConfirmResult confirm)
        {
            _yesNoDialog.Closed -= Hire;
            Close(confirm.Confirm);
        }

        private void Awake()
        {
            _canvas.enabled = false;
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

