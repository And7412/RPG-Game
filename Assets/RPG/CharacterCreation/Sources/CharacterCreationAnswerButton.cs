using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.CharacterCreation
{
    [RequireComponent(typeof(Button))]
    public class CharacterCreationAnswerButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        public event Action<AttributeMock[]> Clicked;
        
        private AttributeMock[] _attributes;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        public void Initialize(AnswerModel model)
        {
            _attributes = model.Attributes;
            _text.SetText(model.AnswerModelText);
        }

        public void SetActive(bool value) => gameObject.SetActive(false);

        private void OnClick()
        {
            Clicked?.Invoke(_attributes);
        }
    }
}

