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

        public UserSaveSystem(UserStorage provider)
        {
            _storage = provider;
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
            List<UserSave> list = new List< UserSave >();
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

            UserSave result;
            DateTime resultDate;
            foreach (var save in saves)
            {
                var longDate = save.SaveDate;
                var date = DateTime.FromBinary(longDate);
                if (resultDate != null)
                {
                    if (DateTime.Compare(resultDate, date) > 0)
                    {
                        resultDate = date;
                    }
                }
                else
                {
                    resultDate = date;
                }
                //TODO compare dates
            }

            //temporary
            return saves[saves.Length - 1];
        }
    }
}

