using System;

namespace RPG.Shared.UserData
{
    [Serializable]
    public class UserSave
    {
        public string Name;
        public long SaveDate;
        public PlayerSave PlayerSave;
        public VendorSave[] VendorSave;
    }
}
