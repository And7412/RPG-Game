namespace RPG.Shared.UserData
{
    public interface ISavable<T>
    {
        T GetForSave();
    }
}

