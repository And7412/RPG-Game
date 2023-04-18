using RPG.Shared.UserData;
using RPG.Shared.UserData.HeroSave;

namespace RPG.GameMap
{
    public class GameMapUserSaveBuffer : UserSaveBuffer
    {
        private readonly ISavable<HeroData> _playerSave;

        public GameMapUserSaveBuffer(UserSave save, ISavable<HeroData> playerSave) : base(save)
        {
            _playerSave = playerSave;
        }

        protected override void DoBuild()
        {
            Save.PlayerHeroData = _playerSave.GetForSave();
        }
    }
}

