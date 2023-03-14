using System.Collections;
using System.Collections.Generic;
using RPG.Metagame.Player;
using RPG.Shared.Dialog;

namespace RPG.CharacterCreation
{
    public class CreationQuestionnareDialog : Dialog<CreationQuestionnareArgs, CreationQuestionnareResult>
    {
        protected override void OnOpen(CreationQuestionnareArgs args)
        {

        }

        protected override void OnClose(CreationQuestionnareResult args)
        {

        }
    }
    public class CreationQuestionnareResult : DialogResult
    {
        public readonly AttributeMock[] playerAttributes;

        public CreationQuestionnareResult(AttributeMock[] attributes)
        {
            playerAttributes = attributes;
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
