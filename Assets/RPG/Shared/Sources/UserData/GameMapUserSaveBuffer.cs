using System.Collections.Generic;
using RPG.Shared.UserData;
using RPG.Shared.UserData.HeroSave;

namespace RPG.GameMap
{
    public class GameMapUserSaveBuffer : UserSaveBuffer
    {
        private readonly ISavable<HeroData> _playerSave;
        private readonly ISavable<VendorSave>[] _vendorSaves;

        public GameMapUserSaveBuffer(UserSave save, ISavable<HeroData> playerSave, ISavable<VendorSave>[] vendors) : base(save)
        {
            _playerSave = playerSave;
            _vendorSaves = vendors;
        }

        protected override void DoBuild()
        {
            Save.PlayerHeroData = _playerSave.GetForSave();
            var vendorSaves = new List<VendorSave>();

            foreach (var vendor in _vendorSaves)
            {
                var vendorSave = vendor.GetForSave();
                vendorSaves.Add(vendorSave);
            }

            Save.VendorsData = new VendorsData()
            {
                VendorSaves = vendorSaves.ToArray()
            };
        }
    }
}

