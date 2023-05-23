using RPG.Metagame.InventorySystem;

namespace RPG.Metagame.Heroes.Player
{
    public interface IPlayerTrade
    {
        Money Money { get; }
        IInventoryRead Inventory { get; }
    }
}

