using Core.Saves;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG.Shared.UserData
{
    public class UserSaveSystem
    {
        private readonly UserStorage _storage;

        private UserSave _currentSave;

        public UserSaveSystem(UserStorage storage)
        {
            _storage = storage;
            _currentSave = GetDefaultSave();
        }

        public void Save(string name)
        {
            //TODO how to save in long
            //_currentSave.SaveDate = DateTime.DateTime.Now;
            _storage.SaveByName(_currentSave, name);
        }

        public bool DoesSaveExist(string name)
        {
            var saves = LoadAllSaves();
            return saves.Any(x => x.Name == name);
        }

        public UserSave Load(string name)
        {
            return _storage.LoadByName<UserSave>(name);
        }

        public UserSave[] LoadAllSaves()
        {
            var keysVault = PrefsJsonProvider.Load<PreferencesKeysVault>();
            var keys = keysVault.Keys;
            List<UserSave> list = new List<UserSave>();

            foreach (var key in keys)
            {
                list.Add(PrefsJsonProvider.LoadByName<UserSave>(key)); 
            }
            return list.ToArray();
        }

        public void DeleteSave(string name)
        {
            _storage.DeleteByName<UserSave>(name);
        }

        private UserSave GetDefaultSave()
        {
            var saves = LoadAllSaves();

            if (saves.Length == 0)
                return new UserSave();

            UserSave result = saves[0];
            DateTime resultDate = DateTime.MinValue;
            foreach (var save in saves)
            {
                var longDate = save.SaveDate;
                var date = DateTime.FromBinary(longDate);

                if (date > resultDate)
                {
                    result = save;
                    resultDate = date;
                }
            }

            return result;
        }
    }
}

