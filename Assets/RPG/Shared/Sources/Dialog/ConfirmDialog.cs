using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Shared.Dialog
{
    public class ConfirmDialog :Dialog<DialogConfirmArgs, DialogResult>
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Button _button;

        protected override void OnOpen(DialogConfirmArgs args)
        {
            _button.onClick.AddListener(Confirm);
            _text.text = args.Text;
        }

        public void Confirm()
        {
            _button.onClick.RemoveListener(Confirm);
            SetResult(new DialogResult());
        }
    }
}