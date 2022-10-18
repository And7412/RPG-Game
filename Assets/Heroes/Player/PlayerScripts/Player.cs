using RPG.InventorySystem;
using RPG.Shared;

namespace RPG.PlayerSystem
{
    public class Player : IPlayerTrade
    {
        private readonly PlayerStat _health;
        private readonly PlayerStat _stamina;
        private readonly Money _money;
        private readonly Inventory _inventory;

        public IPlayerStat Health => _health;
        public IPlayerStat Stamina => _stamina;
        public Money Money => _money;

        public IInventoryRead Inventory => _inventory;

        public Player(PlayerConfig config)
        {
            _health = new PlayerStat(config.MaxHealth);
            _stamina = new PlayerStat(config.MaxStamina);
            var money = 10;
            _money = new Money(money);
            _inventory = config.Inventory;

            var health = PrefsProvider.LoadPlayerHealth();
            SetMaxHP();
        }

        public void Hit()
        {
            _health.Decrease(10);
            PrefsProvider.SavePlayerHealth(_health.Value);
        }

        public void SetMaxHP()
        {
            _health.Set(_health.MaxValue);
            PrefsProvider.SavePlayerHealth(_health.Value);
        }
    }
}

