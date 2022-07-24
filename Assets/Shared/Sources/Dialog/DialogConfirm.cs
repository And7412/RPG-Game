using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Shared.Dialog
{
    public class DialogConfirm : MonoBehaviour, IDialog<DialogArgs, DialogConfirmResult>
    {
        public event Action<DialogConfirmResult> Closed;


        public void Open(DialogArgs args)
        {
            throw new NotImplementedException();
        }
        public void Confirm(bool Valiu)
        {
            var Result = new DialogConfirmResult(Valiu);
            Closed?.Invoke(Result);
        }
    }
    public class DialogConfirmResult : DialogResult
    {
        private bool _confirm;
        public DialogConfirmResult(bool confirm)
        {
            _confirm = confirm;
        }
    }
}
