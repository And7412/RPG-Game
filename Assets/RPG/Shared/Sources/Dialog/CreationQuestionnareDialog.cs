using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RPG.Metagame.Player;
using RPG.Shared.Dialog;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.CharacterCreation
{
    public class CreationQuestionnareDialog : Dialog<CreationQuestionnareArgs, CreationQuestionnareResult>
    {
        private QuestionConfig _config;
        [SerializeField] private AttributeMockButton[] _attributeMockButtons;
        private AttributeMock[] _resultAttributes;
        protected override void OnOpen(CreationQuestionnareArgs args)
        {
            _config = args.Config;
            foreach(var _attributeMockButton in _attributeMockButtons)
            {
                //_attributeMockButton.button.onClick => SetAtrebuts(_attributeMockButton);
            }
        }

        protected override void OnClose(CreationQuestionnareResult args)
        {
            foreach (var _attributeMockButton in _attributeMockButtons)
            {
                _attributeMockButton.button.onClick.RemoveAllListeners();
                
            }
        }

        private void Genrration(AttributeMockButton[] _attributeMocks)
        {
            List<AttributeMock> attributes=new List<AttributeMock>;
             foreach(AttributeMockButton attributeMock in _attributeMockButtons)
             {
                attributes.Add(attributeMock._attributeMock);
             }
        } 

        public void SetAtrebuts(AttributeMockButton attributs)
        {
            List<AttributeMock> result=new List<AttributeMock>;
            result.AddRange(_resultAttributes);
            result.Add(attributs._attributeMock);
            _resultAttributes = result.ToArray();
        }





        private class AttributeMockButton
        {
            public Button button;
            public AttributeMock _attributeMock;
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
