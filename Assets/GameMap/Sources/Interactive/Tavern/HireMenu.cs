using RPG.Heroes.Tavern;
using RPG.PlayerSystem;
using RPG.Shared.Dialog;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace RPG.GameMap.Tavern
{
    public class HireMenu : MonoBehaviour, IDialog<HireMenuArgs, HireMenuResult>
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Image _heroIconImage;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private Button _hireButton;
        [SerializeField] private Button _cancelButton;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private DialogConfirm _confirmDialog;
        [SerializeField] private string _confirmText;
        [SerializeField]private DialogConfitmTrue _confitmTrue;
        private CheckMissingCoins _checkMissingCoins;

        private TavernHeroConfig _current;

        public event Action<HireMenuResult> Closed;

        public void Open(HireMenuArgs args)
        {
            
            _hireButton.onClick.AddListener(OnHireButtonClicked);
            _cancelButton.onClick.AddListener(OnCancelButtonClicked);
            _current = args.HeroConfig;
            _priceText.text = _current.Price.ToString();

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
            if (!_checkMissingCoins.TryMissingCoins(_current.Price))
            {
                //$"Хотите ли вы приобрести героя {heroName} за {price} монет? 
                // У вас {n} монет"
                var args = new DialogConfirmArgs(_confirmText);
                _confirmDialog.Closed += Hire;
                _confirmDialog.Open(args);
            }
            else
            {
                _confitmTrue.Closed += CloseDialogCnfirmTrue;
            }
        }

        private void CloseDialogCnfirmTrue(DialogResult result)
        {
            _confitmTrue.Closed -= CloseDialogCnfirmTrue;
            Close(false);
        }
        private void OnCancelButtonClicked()
        {
            Close(false);
        }

        private void Hire(DialogConfirmResult confirm)
        {
            _confirmDialog.Closed -= Hire;
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

        public HireMenuArgs(TavernHeroConfig heroConfig)
        {
            HeroConfig = heroConfig;
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

