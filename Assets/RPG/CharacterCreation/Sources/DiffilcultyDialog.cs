using RPG.Metagame;
using RPG.Shared.Dialog;
using UnityEngine;

namespace RPG.CharacterCreation
{
    public class DiffilcultyDialog : Dialog<DialogArgs, DifficultyDialogResult>
    {
        [SerializeField] private CharacterCreationDifficultyButton[] _buttons;

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
        public Difficulty Difficulty { get; }
        public DifficultyDialogResult(Difficulty difficulty)
        {
            Difficulty = difficulty;
        }
    }
}