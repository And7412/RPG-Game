using RPG.Shared;

namespace RPG.PlayerSystem
{
    public class Player
    {
        private readonly PlayerStat _health;
        private readonly PlayerStat _stamina;

        public IPlayerStat Health => _health;
        public IPlayerStat Stamina => _stamina;

        public Player(PlayerConfig config)
        {
            _health = new PlayerStat(config.MaxHealth);
            _stamina = new PlayerStat(config.MaxStamina);

            var health = PrefsProvider.LoadPlayerHealth();
            _health.Set(health);
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

