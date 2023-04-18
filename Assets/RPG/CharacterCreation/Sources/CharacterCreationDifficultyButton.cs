using System;
using RPG.Metagame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.CharacterCreation
{
    [RequireComponent(typeof(Button))]
    public class CharacterCreationDifficultyButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textTMPro;
        [SerializeField] private string _text;
        [SerializeField] private Difficulty _difficulty;
        public event Action<Difficulty> Clicked;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
            
            _textTMPro.SetText(_text);
        }
        private void OnClick()
        {
            Clicked?.Invoke(_difficulty);
        }
    }
}

