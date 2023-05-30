using RPG.Metagame.Heroes.Player;
using RPG.Metagame.InventorySystem.View;
using RPG.Shared.Animations;
using UnityEngine;

namespace RPG.Metagame.MainUI
{
    public class InformationPanel : MonoBehaviour
    {
        [SerializeField] private StatPanel _statPanel;
        [SerializeField] private BoolAnimator _animator;
        [SerializeField] private InventoryView _inventory;
        
        public bool Opened { get; private set; }


        public void Initialize(IPlayer player)
        {
            _statPanel.Initialize(player);
            _inventory.Initialize(player.Inventory);
        }

        public void Open()
        {
            Refresh();
            _animator.Show();
            Opened = true;
        }

        public void Hide()
        {
            Opened = false;
            _animator.Hide();
        }

        public void Refresh()
        {
            _statPanel.Refresh();
        }
    }
}

