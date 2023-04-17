using RPG.Metagame;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.CharacterCreation.DiffilcultyDialog
{
    [RequireComponent(typeof(Button))]
    public class CharacterCreationDifficultyButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textTMPro;
        [SerializeField] private string _text;
        private Button _button;
        [SerializeField] private Difficulty _difficulty;
        public event Action<Difficulty> Clicked;
        public Difficulty Difficulty => _difficulty;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }
        private void OnClick()
        {
            Clicked?.Invoke(_difficulty);
        }
    }
}

