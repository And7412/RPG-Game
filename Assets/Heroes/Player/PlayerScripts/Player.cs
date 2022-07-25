using RPG.Shared;

namespace RPG.PlayerSystem
{
    public class Player : IPlayerTrade
    {
        private readonly PlayerStat _health;
        private readonly PlayerStat _stamina;
        private readonly PlayerMoney _money;

        public IPlayerStat Health => _health;
        public IPlayerStat Stamina => _stamina;
        public PlayerMoney Money => _money;

        public Player(PlayerConfig config)
        {
            _health = new PlayerStat(config.MaxHealth);
            _stamina = new PlayerStat(config.MaxStamina);
            var money = 10;
            _money = new PlayerMoney(money);

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

