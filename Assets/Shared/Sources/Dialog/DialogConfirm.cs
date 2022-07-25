using System;
using TMPro;
using UnityEngine;

namespace RPG.Shared.Dialog
{
    public class DialogConfirm : MonoBehaviour, IDialog<DialogConfirmArgs, DialogConfirmResult>
    {
        public event Action<DialogConfirmResult> Closed;

        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Canvas _canvas;

        private void Awake()
        {
            _canvas.enabled = false;
        }

        public void Open(DialogConfirmArgs args)
        {
            _text.text = args.Text;
            _canvas.enabled = true;
        }

        public void Confirm(bool value)
        {
            var result = new DialogConfirmResult(value);
            _canvas.enabled = false;
            Closed?.Invoke(result);
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
