using System;
namespace RPG.Metagame.Player
{
    public class PlayerLevel
    {
        public int Xp { get; private set; }
        public int Level { get; private set; }
        public int XpToNextLevel { get; private set; }

        private int _difficultyFactor=1;
        private const int ConstantFactor = 100;
        private int _classFactorHp=100;
        private int _classFactorStamina=100;

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

        public int GetMaxHealth(int defaultMaxHp)
        {
            var result = defaultMaxHp + StatModifier + _classFactorHp;
            return result;
        }

        public int GetMaxHealth(int defaultMaxHp,int armorStamiHealthFactor)
        {
            var result = defaultMaxHp + StatModifier+_classFactorHp + armorStamiHealthFactor;
            return result;
        }

        public int GetMaxStamina(int defaultMaxStamina)
        {
            var result = defaultMaxStamina + StatModifier;
            return result;
        }

        public int GetMaxStamina(int defaultMaxStamina,int armorStaminaFactor)
        {
            var result = defaultMaxStamina + StatModifier + _classFactorStamina + armorStaminaFactor;
            return result;
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
}
