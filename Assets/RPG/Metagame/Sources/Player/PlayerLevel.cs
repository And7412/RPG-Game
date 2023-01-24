using System;
namespace RPG.Metagame.Player
{
    public class PlayerLevel
    {
        public int Xp { get; private set; }
        public int Level { get; private set; }
        public int XpToNextLevel { get; private set; }

        private int _diffikaltyFactor=1;

        private const int ConstentFactor = 100;


        private readonly int _ratio = 100;

        public PlayerLevel(int xp, int lvl, int ratio )
        {
            if (xp < 0 || lvl < 0 || _ratio <= 0)
            {
                throw new ArgumentException();
            }

            if (_diffikaltyFactor <= 0)
                _diffikaltyFactor = 1;

            if (_diffikaltyFactor > 100)
                _diffikaltyFactor = 100;

            Xp = xp;
            Level = lvl;
            _ratio = ratio;
            XpToNextLevel = Level * _ratio;
        }

        public int PlayerUpdateState()
        {
            var Result = Level * ConstentFactor / _diffikaltyFactor;
            if(Level * ConstentFactor % _diffikaltyFactor != 0)
            {
                Result -= Level * ConstentFactor % _diffikaltyFactor;
            }
            return Result;
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
            XpToNextLevel = Level * _ratio;
        }
    }
}
