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
            _text.text = args.Text;
        }

        private void ToMain()
        {
            Closed?.Invoke(new ExitDialogResult(false));
        }
        private void ToExit()
        {
            Closed?.Invoke(new ExitDialogResult(true));
        }


    }
    public class ExitDialogArgs : DialogArgs
    {
        public string Text;
        public string TextButtonMainMenu;
        public string TextButtonExit;
        public ExitDialogArgs(string text, string textButtonExit, string textButtonMainMenu)
        {
            Text = text;
            TextButtonExit = textButtonExit;
            TextButtonMainMenu = textButtonMainMenu;
        }

    }
    public class ExitDialogResult : DialogResult
    {
        public bool ToExit { get; }
        public ExitDialogResult(bool toExit)
        {
            ToExit = toExit;
        }

    }
}
