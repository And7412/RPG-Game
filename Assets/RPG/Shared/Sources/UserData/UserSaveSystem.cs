using Core.Saves;
using System;
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
                
                //TODO compare dates
            }

            //temporary
            return saves[saves.Length - 1];
        }
    }
}

