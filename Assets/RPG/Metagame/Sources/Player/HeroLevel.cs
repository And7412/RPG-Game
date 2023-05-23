using System;

namespace RPG.Metagame.Heroes.Player
{
    public class HeroLevel : ILevelStat
    {
        public int Xp { get; private set; }
        public int Level { get; private set; }
        public int XpToNextLevel { get; private set; }

        private int _difficultyFactor=1;

        private readonly int _xpRatio = 100;

        public HeroLevel(int xp, int lvl, int xpRatio, Difficulty difficulty)
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

        public void IncreaseXp(int value)
        {
            if (value < 0)
                throw new ArgumentException("xp is lower then zero");

            var xp = value * ((float)Difficulty.Medium / _difficultyFactor);
            Xp = (int)xp;
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

    public interface ILevelStat
    {
        int Xp { get; }
        int Level { get; }
        int XpToNextLevel { get; }
    }
}
