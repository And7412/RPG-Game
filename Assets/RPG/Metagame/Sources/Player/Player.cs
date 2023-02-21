using RPG.Metagame.InventorySystem;
using RPG.Shared;
using System.Linq;
using RPG.Shared.UserData;

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
        public IPlayerLevelStat Level => _level;
        public string Name { get; }

        private PlayerLevel _level;

        public Player(PlayerConfig config, PlayerSave save)
        {
            PlayerLevel level = new PlayerLevel(save.Xp, save.Level, config.XpRatio, save.DifficultyEnum);
            Name = save.Name;
            _health = new PlayerStat(level.GetMaxHealth(config.MaxHealth));
            _health.Set(save.Health);

            _stamina = new PlayerStat(level.GetMaxStamina(config.MaxStamina));
            _stamina.Set(save.Stamina);

            var money = save.Money;
            _money = new Money(money);

            _inventory = new Inventory();

            //foreach(var item in save.InventoryItems)
            //{
            //    _inventory.AddItems(item.Id, item.Count);
            //}
        }

        public void Hit()
        {
            _health.Decrease(10);
            //PrefsProvider.SavePlayerHealth(_health.Value);
        }

        public void SetMaxHP()
        {
            _health.Set(_health.MaxValue);
            //PrefsProvider.SavePlayerHealth(_health.Value);
        }

        public PlayerSave GetSave()
        {
            return new PlayerSave
            {
                Name = Name,
                Level = _level.Level,
                Xp = _level.Xp,
                //TODO
            };

        }
    }
}

