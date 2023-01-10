using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Metagame.InventorySystem.View
{
    [RequireComponent(typeof(Button))]
    public class InventorySectionButton : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _selectedBool = "Selected";
        [SerializeField] private InventorySlotType _sectionType;

        private Button _button;

        public event Action<InventorySectionButton> Clicked;
        public InventorySlotType SectionType => _sectionType;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);   
        }

        public void SetSelected(bool value)
        {
            _animator.SetBool(_selectedBool, value);
        }

        private void OnClick()
        {
            Clicked?.Invoke(this);
        }
    }
}
