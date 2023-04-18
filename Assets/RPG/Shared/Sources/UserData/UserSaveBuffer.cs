namespace RPG.Shared.UserData
{
    public abstract class UserSaveBuffer
    {
        protected UserSave Save => _save;
        private readonly UserSave _save;

        public UserSaveBuffer(UserSave save)
        {
            _save = save;
        }

        public UserSave BuildSave()
        {
            DoBuild();
            return Save;
        }

        protected abstract void DoBuild();
    }
}
