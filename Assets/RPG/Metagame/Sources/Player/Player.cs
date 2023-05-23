using RPG.Metagame.InventorySystem;
using RPG.Shared.UserData;
using RPG.Shared.UserData.HeroSave;

namespace RPG.Metagame.Heroes.Player
{
    public class Player : IPlayer, ISavable<HeroData>
    {
        private readonly PlayerStat _health;
        private readonly PlayerStat _mana;
        private readonly Money _money;
        private readonly Inventory _inventory;
        private readonly HeroStatCalculator<PlayerConfig> _finalPlayerStat;
        private readonly PlayerAttributes _attributes;

        public IStat Health => _health;
        public IStat Mana => _mana;
        public Money Money => _money;

        public IInventoryRead Inventory => _inventory;
        public ILevelStat Level => _level;
        public string Name { get; }
        public IGetAttribute GetAttribute => _attributes;

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

            _attributes = new PlayerAttributes(save.Attributes);
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

        public HeroData GetForSave()
        {
            var attributes = _attributes.GetForSave();
            //TODO 
            return new HeroData();
        }
    }
    public interface IPlayer: IPlayerTrade
    {
        IStat Mana { get; }
        IStat Health { get; }
        ILevelStat Level { get; }
        IGetAttribute GetAttribute { get; }
    }
}

