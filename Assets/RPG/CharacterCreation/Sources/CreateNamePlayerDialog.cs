using Core.Patterns.ServiceLocator;
using RPG.Shared.Dialog;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.CharacterCreation
{
    public class CreateNamePlayerDialog : Dialog<DialogCreateNamePlayerArg, DialogCreateNamePlayerResult>
    {
        [SerializeField] private TextMeshProUGUI _register_username;
        [SerializeField] private Button _exitButton;
        [SerializeField] private EnterKeyObserver _enterObserver;
        [SerializeField] private string _confirmDialogQuestion="Начать как {0}";

        private string _playerName;

        protected override void OnAwake()
        {
            base.OnAwake();
            _exitButton.onClick.AddListener(OnClickToExitButton);
            _enterObserver.EnterEvent += OnClickToExitButton;
            
        }

        private async void OnClickToExitButton()
        {
            _playerName = _register_username.text;
            var dialogsService = ServiceLocator.Instance.GetService<DialogsService>();
            var confirmString = string.Format(_confirmDialogQuestion, _playerName);
            var confirmResult = await dialogsService.InvokeYesNoDialog(new DialogConfirmArgs(confirmString));
            if (confirmResult.Confirm)
            {
                SetResult(new DialogCreateNamePlayerResult(_playerName));
            }
        }

        protected override void OnClose(DialogCreateNamePlayerResult args)
        {
            base.OnClose(args);
            _enterObserver.EnterEvent -= OnClickToExitButton;
        }

    }

    public class DialogCreateNamePlayerArg : DialogArgs{}
    
    public class DialogCreateNamePlayerResult: DialogResult
    {
        public string Name { get; }
        public DialogCreateNamePlayerResult(string name)
        {
            Name = name;
        }
    }
}

