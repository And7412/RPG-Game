namespace Core.Patterns.Pool
{
    public interface IPoolable
    {
        bool Active { get; }
        void SetActive(bool value);
    }
}

