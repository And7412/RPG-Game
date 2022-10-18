using RPG.InventorySystem;

namespace RPG.PlayerSystem
{
    public interface IPlayerTrade
    {
        PlayerMoney Money { get; }
        IInventoryRead Inventory { get; }
    }
}

