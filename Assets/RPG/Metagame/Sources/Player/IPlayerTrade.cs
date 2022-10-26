using RPG.Metagame.InventorySystem;

namespace RPG.Metagame.Player
{
    public interface IPlayerTrade
    {
        Money Money { get; }
        IInventoryRead Inventory { get; }
    }
}

