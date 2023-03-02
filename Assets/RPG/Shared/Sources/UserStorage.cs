namespace Core.Saves
{
    public class UserStorage
    {
        public T Load<T>() where T : new()
        {
            return PrefsJsonProvider.Load<T>();
        }

        public T LoadByName<T>(string name) where T : new()
        {
            return PrefsJsonProvider.LoadByName<T>(name);
        }

        public void Save<T>(T value) where T : new()
        {
            PrefsVault.AddSave(typeof(T).Name);
            PrefsJsonProvider.Save(value);
        }

        public void SaveByName<T>(T value, string name) where T : new()
        {
            PrefsVault.AddSave(name);
            PrefsJsonProvider.SaveByName(value, name);
        }

        public void DeleteByName<T>(string name)
        {
            var saveName = PrefsJsonProvider.GetSaveName(typeof(T), name);
            PrefsVault.RemoveSave(saveName);
            PrefsJsonProvider.DeleteSaveByName<T>(name);
        }

        public void DeleteSave<T>()
        {
            PrefsVault.RemoveSave(typeof(T).Name);
            PrefsJsonProvider.DeleteSave<T>();
        }
    }
}

