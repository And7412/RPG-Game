using RPG.Shared;

namespace RPG.PlayerSystem
{
    public class Player
    {
        public PlayerStat Health { get; private set; }
        public PlayerStat Stamina { get; private set; }

        public Player(PlayerConfig config)
        {
            Health = new PlayerStat(config.MaxHealth);
            Stamina = new PlayerStat(config.MaxStamina);

            var health = PrefsProvider.LoadPlayerHealth();
            Health.Set(health);
        }

        public void Hit()
        {
            Health.Decrease(10);
            PrefsProvider.SavePlayerHealth(Health.Value);
        }

        public void SetMaxHP()
        {
            Health.Set(Health.MaxValue);
            PrefsProvider.SavePlayerHealth(Health.Value);
        }
    }
}

