using RPG.Metagame.InventorySystem;
using RPG.Shared;
using System.Linq;
using RPG.Shared.UserData;
using RPG.Shared.UserData.HeroSave;

namespace RPG.Metagame.Player
{
    public class Player : IPlayerTrade
    {
        private readonly PlayerStat _health;
        private readonly PlayerStat _stamina;
        private readonly Money _money;
        private readonly Inventory _inventory;
        private readonly HeroStatCalculator<PlayerConfig> _finalPlayerStat;

        public IPlayerStat Health => _health;
        public IPlayerStat Stamina => _stamina;
        public Money Money => _money;

        public IInventoryRead Inventory => _inventory;
        public IPlayerLevelStat Level => _level;
        public string Name { get; }

        private HeroLevel _level;

        public Player(PlayerConfig config, HeroData save, Difficulty difficulty, string name)
        {
            HeroLevel level = new HeroLevel(save.LevelData.Xp, save.LevelData.Level, config.XpRatio, difficulty);
            Name = name;
            _finalPlayerStat = new HeroStatCalculator<PlayerConfig>(level, difficulty);
            _health = new PlayerStat(_finalPlayerStat.SetMaxHealth(config));
            //TODO
            //_health.Set(save.Health);

            //TODO
            // _stamina = new PlayerStat(save.Stamina);
            // _stamina.Set(save.Stamina);

            var money = save.InventoryData.Money;
            _money = new Money(money);

            _inventory = new Inventory();

            //TODO
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

        public HeroData GetSave()
        {
            return new HeroData()
            {
                //TODO
            };

        }
    }
}

