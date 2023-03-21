using System;
using RPG.Shared.Dialog;
using UnityEngine;

namespace RPG.CharacterCreation
{
    public class CreationQuestionnareDialog : Dialog<CreationQuestionnareArgs, CreationQuestionnareResult>
    {
        [SerializeField] private CharacterCreationAnswerButton[] _answerButtons;
        private AttributeMock[] _resultAttributes;
        
        protected override void OnAwake()
        {
            foreach (var button in _answerButtons)
            {
                button.Clicked += AnswerButtonOnClick;
            }
        }

        private void AnswerButtonOnClick(AttributeMock[] attributes)
        {
            SetResult(new CreationQuestionnareResult(attributes));
        }

        protected override void OnOpen(CreationQuestionnareArgs args)
        {
            var answers = args.Config.AnswerModel;
            
            if (answers.Length > _answerButtons.Length)
                throw new InvalidOperationException("Too many answers for button list");
            
            for (int j = 0; j < _answerButtons.Length; j++)
            {
                var button = _answerButtons[j];
                bool buttonActive = j < answers.Length;
                button.SetActive(buttonActive);
                
                if (!buttonActive)
                    continue;

                var answer = answers[j];
                button.Initialize(answer);
            }
        }


    }
    public class CreationQuestionnareResult : DialogResult
    {
        public readonly AttributeMock[] PlayerAttributes;

        public CreationQuestionnareResult(AttributeMock[] attributes)
        {
            PlayerAttributes = attributes;
        }
    }
    public class CreationQuestionnareArgs : DialogArgs
    {
        public QuestionConfig Config { get; }
        public CreationQuestionnareArgs(QuestionConfig config)
        {
            Config = config;
        }
    }
}
