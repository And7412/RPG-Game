using RPG.Metagame.InventorySystem.View;
using UnityEngine;

namespace RPG.Metagame.InventorySystem
{
    public class InventoryButtons : MonoBehaviour
    {
        [SerializeField] private InventorySectionButton[] _buttons;

        private IInventoryView _inventory;

        public void Initialize(IInventoryView inventory)
        {
            _inventory = inventory;

            foreach (var button in _buttons)
            {
                button.Clicked += OnButtonClicked;
            }

            OnButtonClicked(_buttons[0]);
        }

        private void OnButtonClicked(InventorySectionButton button)
        {
            SelectButton(button.SectionType);

            switch (button.SectionType)
            {
                case InventorySlotType.Weapon:
                    _inventory.ShowWeapon();
                    return;
                case InventorySlotType.Armor:
                    _inventory.ShowArmor();
                    return;
                case InventorySlotType.Consume:
                    _inventory.ShowConsumables();
                    return;
                case InventorySlotType.Misc:
                    _inventory.ShowMisc();
                    return;
                case InventorySlotType.Quest:
                    _inventory.ShowQuest();
                    return;
            }
        }

        private void SelectButton(InventorySlotType slotType)
        {
            foreach (var button in _buttons)
            {
                var selected = slotType == button.SectionType;
                button.SetSelected(selected);
            }
        }
    }
}