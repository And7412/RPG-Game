using RPG.InventorySystem;

namespace RPG.PlayerSystem
{
    public interface IPlayerTrade
    {
        Money Money { get; }
        IInventoryRead Inventory { get; }
    }
}

