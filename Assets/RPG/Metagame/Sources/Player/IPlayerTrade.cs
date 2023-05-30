using RPG.Metagame.InventorySystem;

namespace RPG.Metagame.Heroes.Player
{
    public interface IPlayerTrade
    {
        IInventoryRead Inventory { get; }
    }
}

