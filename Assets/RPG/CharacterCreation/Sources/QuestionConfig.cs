using RPG.Metagame.Heroes.Player;
using System;
using UnityEngine;

namespace RPG.CharacterCreation
{
    [CreateAssetMenu(fileName = "QuestionConfig",menuName = "RPG/CharacterCreation/QuestionConfig")]
    public class QuestionConfig : ScriptableObject
    {
        [SerializeField] private string _questionText;
        [SerializeField] private AnswerModel[] _answerModel;

        public string QuestionText => _questionText;
        public AnswerModel[] AnswerModel => _answerModel;
    }
    [Serializable]
    public class AnswerModel
    {
        [SerializeField] private string _answerModelText;
        [SerializeField] private AttributeMock[] _attributes;

        public string AnswerModelText => _answerModelText;
        public AttributeMock[] Attributes => _attributes;
    }
    [Serializable]
    public class AttributeMock
    {
        [SerializeField] private int _value;
        [SerializeField] private AttributeName _name;

        public int Value => _value;
        public AttributeName Name => _name;
    }
}
