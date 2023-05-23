using RPG.Metagame.Heroes.Player;
using RPG.Metagame.InventorySystem.View;
using RPG.Shared.Animations;
using UnityEngine;

public class InformationPlanelControler : MonoBehaviour
{
    [SerializeField] private StatPanel _statPanel;
    [SerializeField] private BoolAnimator _animator;
    [SerializeField] private InventoryView _inevntory;


    public void Initialize(IPlayer player)
    {
        _statPanel.Initialize(player);
        _inevntory.Initialize(player.Inventory);
    }
}
