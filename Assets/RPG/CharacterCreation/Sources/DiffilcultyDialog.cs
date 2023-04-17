using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Shared.Dialog;
using RPG.Metagame;
using System.Threading.Tasks;
using TMPro;

namespace RPG.CharacterCreation.DiffilcultyDialog
{
    public class DiffilcultyDialog : Dialog<DialogArgs, DifficultyDialogResult>
    {
        [SerializeField] private CharacterCreationDifficultyButton[] _buttons;
        [SerializeField] private TMP_Text _textTMPro;
        [SerializeField] private string _text;

        protected override void OnOpen(DialogArgs args)
        {
            foreach(var button in _buttons)
            {
                button.Clicked += DifficultyButtonOnClick;
            }
        }
        private void DifficultyButtonOnClick(Difficulty difficulty)
        {
            SetResult(new DifficultyDialogResult(difficulty));
        }
    }
    public class DifficultyDialogResult : DialogResult
    {
        private Difficulty _difficulty;
        public DifficultyDialogResult(Difficulty difficulty)
        {
            difficulty = _difficulty;
        }
    }
}