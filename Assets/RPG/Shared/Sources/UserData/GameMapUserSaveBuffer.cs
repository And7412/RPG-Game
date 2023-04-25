using System.Collections.Generic;
using RPG.Shared.UserData;
using RPG.Shared.UserData.HeroSave;

namespace RPG.GameMap
{
    public class GameMapUserSaveBuffer : UserSaveBuffer
    {
        private readonly ISavable<HeroData> _playerSave;
        private readonly ISavable<VendorsData> _vendorSaves;

        public GameMapUserSaveBuffer(UserSave save, ISavable<HeroData> playerSave, ISavable<VendorsData> market) : base(save)
        {
            _playerSave = playerSave;
            _vendorSaves = market;
        }

        protected override void DoBuild()
        {
            Save.PlayerHeroData = _playerSave.GetForSave();
            Save.VendorsData = _vendorSaves.GetForSave();
        }
    }
}

