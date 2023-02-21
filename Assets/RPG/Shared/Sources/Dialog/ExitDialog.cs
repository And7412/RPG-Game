using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Shared.Dialog
{
    public class ExitDialog : Dialog<ExitDialogArgs, ExitDialogResult>
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Button _buttonMainMenu;
        [SerializeField] private Button _ExitButton;

        public event Action<ExitDialogResult> Closed;

        protected override void OnOpen(ExitDialogArgs args)
        {
            _buttonMainMenu.onClick.AddListener(ToMain);
            _ExitButton.onClick.AddListener(ToExit);
        }

        private void ToMain()
        {
            Closed?.Invoke(new ExitDialogResult(ExitType.MainMenu));
        }
        private void ToExit()
        {
            Closed?.Invoke(new ExitDialogResult(ExitType.Game));
        }
    }

    public class ExitDialogArgs : DialogArgs
    {

    }

    public class ExitDialogResult : DialogResult
    {
        public ExitDialogResult(ExitType type)
        {
            Type = type;
        }

        public ExitType Type { get; }
    }

    public enum ExitType
    {
        None, MainMenu, Game
    }
}
