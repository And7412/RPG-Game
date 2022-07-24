using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Shared.Dialog
{
    public class DialogShouldHire : MonoBehaviour ,IDialog<DialogTavernArgs, DialogTavernResult>
    {
        public event Action<DialogTavernResult> Closed;
        private DialogTavernResult Result;
        

        public void Open(DialogTavernArgs args)
        {
            throw new NotImplementedException();
        }
        public void TryHire(bool valie)
        {
            Result = new DialogTavernResult(valie);
            Closed?.Invoke(Result);
        }
    }
    public class DialogTavernArgs : DialogArgs { }
    public class DialogTavernResult : DialogResult
    {
        public bool Hire;
        public DialogTavernResult(bool hire)
        {
            Hire = hire;
        }

    }
}

