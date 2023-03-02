using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Shared.UserData
{
    [Serializable]
    public class UserSave
    {
        public PlayerSave PlayerSave;
        public VendorSave[] VendorSave;
    }
}
