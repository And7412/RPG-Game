using RPG.Shared.Dialog;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.CharacterCreation
{
    public class CreateNamePlayerDialog : Dialog<DialogCreateNamePlayerArg, DialogCreateNamePlayerResult>
    {
        [SerializeField] private TextMeshProUGUI register_username;
        string username;

        protected override void OnOpen(DialogCreateNamePlayerArg arg)
        {
            username = register_username.text;
        }

    }
    public class DialogCreateNamePlayerArg : DialogArgs
    {
    }
    
    public class DialogCreateNamePlayerResult: DialogResult
    {
        public string Name { get; }
        DialogCreateNamePlayerResult(string name)
        {
            Name = name;
        }
    }
}

