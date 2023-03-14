using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Shared.Dialog
{
    public class YesNoDialog :Dialog<DialogConfirmArgs, DialogConfirmResult>
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Button _buttonYes;
        [SerializeField] private Button _buttonNo;

        protected override void OnOpen(DialogConfirmArgs args)
        {
            _buttonYes.onClick.AddListener(Accept);
            _buttonNo.onClick.AddListener(Decline);
            _text.text = args.Text;
        }

        protected override void OnClose(DialogConfirmResult args)
        {
            _buttonYes.onClick.RemoveListener(Accept);
            _buttonNo.onClick.RemoveListener(Decline);
        }

        private void Accept()
        {
            var result = new DialogConfirmResult(true);
            SetResult(result);
        }

        private void Decline()
        {
            var result = new DialogConfirmResult(false);
            SetResult(result);
        }
    }
    
    public class DialogConfirmResult : DialogResult
    {
        public bool Confirm { get; }
        public DialogConfirmResult(bool confirm)
        {
            Confirm = confirm;
        }
    }

    public class DialogConfirmArgs : DialogArgs
    {
        public string Text { get; }
        public DialogConfirmArgs(string text)
        {
            Text = text;
        }
    }
}
