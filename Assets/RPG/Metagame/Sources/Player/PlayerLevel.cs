using System;
namespace RPG.Metagame.Player
{
    public class PlayerLevel : IPlayerLevelStat
    {
        public int Xp { get; private set; }
        public int Level { get; private set; }
        public int XpToNextLevel { get; private set; }

        private int _difficultyFactor=1;
        private const int ConstantFactor = 100;
        private int _statfactorHelse;
        private int _statefactorStamina;

        private readonly int _xpRatio = 100;

        private int StatModifier => (Level-1) * ConstantFactor / _difficultyFactor;

        public PlayerLevel(int xp, int lvl, int xpRatio, Difficulty difficulty)
        {
            if (xp < 0 || lvl < 0 || _xpRatio <= 0)
            {
                throw new ArgumentException();
            }

            if (_difficultyFactor <= 0)
                _difficultyFactor = 1;

            if (_difficultyFactor > 100)
                _difficultyFactor = 100;
            
            Xp = xp;
            Level = lvl;
            _xpRatio = xpRatio;
            XpToNextLevel = Level * _xpRatio;
            SetDifficultyFactor(difficulty);
        }

        public int GetMaxStamina(int defaltMaxStamina, int armorStaminaFactor,int StatFactor)
        {
            _statefactorStamina = StatFactor;
            return GetMaxStat(defaltMaxStamina, armorStaminaFactor, StatFactor);
        }

        public int GetMaxHealth(int defaltMaxHelse, int armorHelseFactor, int StatFactor)
        {
            _statfactorHelse = StatFactor;
            return GetMaxStat(defaltMaxHelse, armorHelseFactor, StatFactor);
        }

        public int GetMaxStamina(int defaltMaxStamina, int StatFactor)
        {
            _statefactorStamina = StatFactor;
            return GetMaxStat(defaltMaxStamina, 0, StatFactor);
        }

        public int GetMaxHealth(int defaltMaxHelse,  int StatFactor)
        {
            _statfactorHelse = StatFactor;
            return GetMaxStat(defaltMaxHelse, 0, StatFactor);
        }

        public int GetMaxStamina(int defaltMaxStamina)
        {
            _statefactorStamina = 0;
            return GetMaxStat(defaltMaxStamina, 0, 0);
        }

        public int GetMaxHealth(int defaltMaxHelse)
        {
            _statfactorHelse = 0;
            return GetMaxStat(defaltMaxHelse, 0, 0);
        }

        private int GetMaxStat(int maxdefault, int armorFactor, int StatFactor)
        {
            
            return maxdefault + StatModifier + armorFactor+StatFactor;
        }

        public void IncreaseXp(int value)
        {
            if (value < 0)
                throw new ArgumentException("xp is lower then zero");

            Xp += value;
            CheckXp();
        }

        private void CheckXp()
        {
            if (Xp < XpToNextLevel)
                return;


            var diff = Xp - XpToNextLevel;
            IncreaseLvl();
            Xp = diff;
        }

        private void IncreaseLvl()
        {
            Level++;
            XpToNextLevel = Level * _xpRatio;
        }

        private void SetDifficultyFactor(Difficulty difficulty)
        {
            _difficultyFactor = (int) difficulty;

            if (_difficultyFactor <= 0)
                _difficultyFactor = 1;
        }
    }

    public interface IPlayerLevelStat
    {
        int Xp { get; }
        int Level { get; }
        int XpToNextLevel { get; }
    }
}
