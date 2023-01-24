using RPG.Metagame.InventorySystem;
using RPG.Shared;
using System.Linq;

namespace RPG.Metagame.Player
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

        public Player(UserSave save)
        {
            PlayerLevel level = new PlayerLevel(save.Level.Xp, save.Level.Level, save.Level.Ratio);
            _health = new PlayerStat(level.PlayerUpdateState());
            _stamina = new PlayerStat(level.PlayerUpdateState());
            var money = save.Money;
            _money = new Money(money);
            _inventory = new Inventory();
            foreach(var item in save.InventoryItemsId)
            {
                _inventory.AddItems(item, 1);
                
            }
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

