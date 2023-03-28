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

        private string _playerName;

        protected override void OnAwake()
        {
            base.OnAwake();
            _exitButton.onClick.AddListener(OnClickToExitButton);
            _enterObserver.EnterEvent += OnClickToExitButton;
        }

        private void OnClickToExitButton()
        {
            _playerName = _register_username.text;
            SetResult(new DialogCreateNamePlayerResult(name));
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

