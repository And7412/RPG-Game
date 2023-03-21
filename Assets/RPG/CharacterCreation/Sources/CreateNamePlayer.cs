using RPG.Shared.Dialog;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.CharacterCreation
{
    public class CreateNamePlayer : Dialog<DialogCreateNamePlayerArg, DialogCreateNamePlayerResult>
    {
        public TMP_Text _text;

        protected override void OnOpen(DialogCreateNamePlayerArg arg)
        {
            _text = arg._text;
            
        }

    }
    public class DialogCreateNamePlayerArg:DialogArgs
    {
        public TMP_Text _text;
        DialogCreateNamePlayerArg(TMP_Text text)
        {
            _text = text;
        }
    }
    public class DialogCreateNamePlayerResult: DialogResult
    {
        public string _name;
        DialogCreateNamePlayerResult(string name)
        {
            _name = name;
        }
    }
}

